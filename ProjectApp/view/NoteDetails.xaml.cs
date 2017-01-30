using ProjectApp.model;
using ProjectApp.viewmodel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace ProjectApp.view
{
    public sealed partial class NoteDetails : Page
    {
        private Note note;

        public NoteDetails()
        {
            InitializeComponent();
            DataContext = new NoteViewModel();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            note = (Note) e.Parameter;

            (DataContext as NoteViewModel).Title = note.Title;
            (DataContext as NoteViewModel).Description = note.Description;
            (DataContext as NoteViewModel).Date = note.Date;
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(EditNote), note);
        }
    }
}
