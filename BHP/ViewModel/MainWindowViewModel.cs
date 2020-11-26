using BHP.Helpers;
using BHP.ViewModel.Abstract;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace BHP.ViewModel
{
    public class MainWindowViewModel:BaseViewModel
    {
        #region Fields
        // okno glowne ma w sobie kolekcje linkow tylko do odczytu
        // - mozna tez uzyc listy
        private ReadOnlyCollection<CommandViewModel> _Commands;
        // okno glowne zawiera tez kolekcje zakladek 
        private ObservableCollection<WorkspaceViewModel> _Workspaces;
        #endregion Fields


        #region CommandsMenu
        //te komendy sa po to zeby dzialalo menu i pasek narzedzi
        public ICommand WszyscyPracownicyCommand
        {
            get
            {
                //komenda towarCommand wywoluje funkcje createTowar, ktora wyswietla nowa zakladke i jest zdefiniowana nizej 
                return new BaseCommand(() => ShowWszyscyPracownicy());
            }
        }
        public ICommand NowyPracownikCommand
        {
            get
            {

                return new BaseCommand(() => createView(new NowyPracownikViewModel()));
            }
        }



        public ICommand NowaFirmaCommand
        {
            get
            {

                return new BaseCommand(() =>  ShowNowaFirma());
            }
        }

        public ICommand ZwolnionyPracownikCommand
        {
            get
            {
                return new BaseCommand(() => ZwolnionyPracownik());
            }
        }

        public ICommand WszyscyZwolnieniCommand
        {
            get
            {
                return new BaseCommand(() => ShowWszystkieZwolnienia());
            }
        }

        public ICommand NoweStanowiskoCommand
        {
            get
            {

                return new BaseCommand(() =>  ShowNoweStanowisko());
            }
        }
        
        public ICommand NowyKontrahentCommand
        {
            get
            {

                return new BaseCommand(() => ShowNowyKontrahent());
            }
        }
        public ICommand WszyscyKontrahenciCommand
        {
            get
            {
                return new BaseCommand(() => ShowWszyscyKontrahenci());
            }
        }
        #endregion CommandsMenu 


        #region Commands
        //tworzymy propertisa do _Commands
        public ReadOnlyCollection<CommandViewModel> Commands
        {
            get
            {
                if (_Commands == null)
                {
                    //tworzymy liste poniewaz readonlycollection nie mozna modifikowac
                    //a zatem cmds jest po to żeby było wzorcem dla readonlycollection
                    List<CommandViewModel> cmds = this.createCommands();
                    _Commands = new ReadOnlyCollection<CommandViewModel>(cmds);
                }
                return _Commands;
            }
        }
        //to jest funckja ktora tworzy komendy
        public List<CommandViewModel> createCommands()
        {
            //tworzymy nowa liste linkow
            return new List<CommandViewModel>
            {
                //kazdy element listy to nowy CommandViewModel o pierwszym parametrze
                //takim jak nazwa linku a drugim parametr mowi jaka funkcje wywolac
                //po kliknieciu
                new CommandViewModel("Nowy Pracownik",
                    new BaseCommand(()=>this.createPracownik())),
                new CommandViewModel("Nowe Stanowisko",
                    new BaseCommand(()=>this.ShowNoweStanowisko())),
                 new CommandViewModel("Nowy Kontrahent",
                    new BaseCommand(()=>this.ShowNowyKontrahent())),
                new CommandViewModel("Nowa Firma",
                    new BaseCommand(()=>this.ShowNowaFirma())),
                new CommandViewModel("Nowe Obuwie",
                    new BaseCommand(()=>this.ShowNoweObowie())),
                new CommandViewModel("Nowa Odziez",
                    new BaseCommand(()=>this.ShowNowaOdziez())),

                new CommandViewModel("Wszyscy Pracownicy",
                    new BaseCommand(()=>this.ShowWszyscyPracownicy())),
                new CommandViewModel("Zwolnienia",
                    new BaseCommand(()=>this.ZwolnionyPracownik())),
                new CommandViewModel("Wszystkie Zwolnienia",
                    new BaseCommand(()=>this.ShowWszystkieZwolnienia())),
                new CommandViewModel("Wszyscy Kontrahenci",
                    new BaseCommand(()=>this.ShowWszyscyKontrahenci())),
            };

        }
        #endregion Commands

        public MainWindowViewModel()
        {
            Messenger.Default.Register<string>(this, open);
        }
        #region Workspaces
        //tworzymy propertisa do pola _Workspaces
        public ObservableCollection<WorkspaceViewModel> Workspaces
        {
            get
            {
                if (_Workspaces == null)
                {
                    _Workspaces = new ObservableCollection<WorkspaceViewModel>();
                    _Workspaces.CollectionChanged += this.onWorkspacesChanged;
                }
                return _Workspaces;
            }
        }
        private void onWorkspacesChanged(object sender,
            NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.NewItems)
                    workspace.RequestClose += this.onWorkspaceRequestClose;
            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.OldItems)
                    workspace.RequestClose -= this.onWorkspaceRequestClose;
        }
        private void onWorkspaceRequestClose(object sender, EventArgs e)
        {
            WorkspaceViewModel workspace = sender as WorkspaceViewModel;
            this.Workspaces.Remove(workspace);
        }
        #endregion Workspaces

        #region Helpers
        //to jest funkcja ktora otworzy zakladke do dodawania towarow i jest
        //podpieta pod link wyzej


        private void createPracownik()
        {
            //tworzymy nowa zakladke do dodawania towaru
            NowyPracownikViewModel workspace = new NowyPracownikViewModel();
            //dodajemy ją do kolekcji zakladek
            this.Workspaces.Add(workspace);
            //i wlaczamy jej aktywnosc
            this.setActiveWorkspace(workspace);
        }
        private void ZwolnionyPracownik()
        {
            //tworzymy nowa zakladke do dodawania towaru
            ZwolnieniePracownikaViewModel workspace = new ZwolnieniePracownikaViewModel();
            //dodajemy ją do kolekcji zakladek
            this.Workspaces.Add(workspace);
            //i wlaczamy jej aktywnosc
            this.setActiveWorkspace(workspace);
        }

        private void ShowWszyscyKontrahenci()
        {
            //tworzymy nowa zakladke do dodawania towaru
            WszyscyKontrahenciViewModel workspace = new WszyscyKontrahenciViewModel();
            //dodajemy ją do kolekcji zakladek
            this.Workspaces.Add(workspace);
            //i wlaczamy jej aktywnosc
            this.setActiveWorkspace(workspace);
            if (workspace == null)
            {
                workspace = new WszyscyKontrahenciViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }

        private void ShowWszystkieZwolnienia()
        {
            //tworzymy nowa zakladke do dodawania towaru
            WszyscyZwolnieniViewModel workspace = new WszyscyZwolnieniViewModel();
            //dodajemy ją do kolekcji zakladek
            this.Workspaces.Add(workspace);
            //i wlaczamy jej aktywnosc
            this.setActiveWorkspace(workspace);
            if (workspace == null)
            {
                workspace = new WszyscyZwolnieniViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }
        private void ShowNowyKontrahent()
        {
            //tworzymy nowa zakladke do dodawania towaru
            NowyKontrahentViewModel workspace = new NowyKontrahentViewModel();
            //dodajemy ją do kolekcji zakladek
            this.Workspaces.Add(workspace);
            //i wlaczamy jej aktywnosc
            this.setActiveWorkspace(workspace);
            if (workspace == null)
            {
                workspace = new NowyKontrahentViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }
        private void ShowNowaOdziez()
        {
            //tworzymy nowa zakladke do dodawania towaru
            NowaOdziezViewModel workspace = new NowaOdziezViewModel();
            //dodajemy ją do kolekcji zakladek
            this.Workspaces.Add(workspace);
            //i wlaczamy jej aktywnosc
            this.setActiveWorkspace(workspace);
            if (workspace == null)
            {
                workspace = new NowaOdziezViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }

        private void ShowWszyscyPracownicy()
        {
            WszyscyPracownicyViewModel workspace =
                this.Workspaces.
                FirstOrDefault(vm => vm is WszyscyPracownicyViewModel)
                as WszyscyPracownicyViewModel;
            if (workspace == null)
            {
                workspace = new WszyscyPracownicyViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }

        private void ShowNoweStanowisko()
        {
            NoweStanowiskoViewModel workspace =
                this.Workspaces.
                FirstOrDefault(vm => vm is NoweStanowiskoViewModel)
                as NoweStanowiskoViewModel;
            if (workspace == null)
            {
                workspace = new NoweStanowiskoViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }
        private void ShowNoweObowie()
        {
            NoweObowieViewModel workspace =
                this.Workspaces.
                FirstOrDefault(vm => vm is NoweObowieViewModel)
                as NoweObowieViewModel;
            if (workspace == null)
            {
                workspace = new NoweObowieViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }

            private void ShowNowaFirma()
        {
            NowaFirmaViewModel workspace =
                this.Workspaces.
                FirstOrDefault(vm => vm is NowaFirmaViewModel)
                as NowaFirmaViewModel;
            if (workspace == null)
            {
                workspace = new NowaFirmaViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }

        private void createView(WorkspaceViewModel workspace)
        {
            Workspaces.Add(workspace);
            this.setActiveWorkspace(workspace);
        }

        ////to jest funkcja ktora wlacza aktywnosc zakladki
        private void setActiveWorkspace(WorkspaceViewModel workspace)
        {
            Debug.Assert(this.Workspaces.Contains(workspace));

            ICollectionView collectionView =
                CollectionViewSource.GetDefaultView(this.Workspaces);
            if (collectionView != null)
                collectionView.MoveCurrentTo(workspace);
        }
        private void open(string komunikat)
        {
         
            if (komunikat == "ZwolnieniaShow")
            {
                ShowWszyscyPracownicy();
            }
            if (komunikat == "NowyKontrahentShow")
            {
                ShowNowyKontrahent();
            }
            if (komunikat == "NowyPracownikShow")
            {
                createView(new NowyPracownikViewModel());
            }
            if (komunikat == "NoweZwolnienieShow")
            {
                createView(new ZwolnieniePracownikaViewModel());
            }
            if (komunikat == "NowaPozycjaObowieAdd")
            {
                createView(new NowaPozycjaViewModel());
            }
        }
        #endregion Helpers
    }
}
