using System.Windows;

using UserSearch.Models;
using UserSearch.Services;
using UserSearch.ViewModels;

namespace UserSearch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IRepository<User, int> _repository;
        private readonly ISerializationService _serializationService;
        public MainWindow()
        {
            InitializeComponent();
            _serializationService = new XmlSerializationService();
            _repository = new UserRepository(_serializationService);
            DataContext = new MainWindowViewModel();
        }
        //private static (Label label, TextBlock textBlock) CreateLableWithTextBlock(string labelText, string textBlockText)
        //{
        //    var label = string.Equals(labelText, "client id", StringComparison.InvariantCultureIgnoreCase) ?
        //        new Label { Content = labelText, HorizontalAlignment = HorizontalAlignment.Left, FontWeight = FontWeights.UltraBold, FontSize = 15.0 } :
        //        new Label { Content = labelText, HorizontalAlignment = HorizontalAlignment.Left, FontWeight = FontWeights.Bold, FontSize = 10.0 };

        //    var textBox = new TextBlock { Text = textBlockText, Margin = new Thickness(5) };
        //    return (label, textBox);
        //}
        //private void FindByFirstName_Clicked(object sender, RoutedEventArgs e)
        //{
        //    var firstName = firstNameOnlyTextBox.Text.ToLowerInvariant();
        //    _panel.Children.Clear();
        //    foreach (var user in _repository.GetAll().Where(user => user.FirstName.ToLowerInvariant() == firstName).ToList())
        //    {
        //        AddUserToStackPanel(user);
        //    }
        //    _panel.Focus();
        //    _panel.BringIntoView();
        //}

        //private void FindByLastName_Clicked(object sender, RoutedEventArgs e)
        //{
        //    var firstName = lastNameOnlyTextBox.Text.ToLowerInvariant();
        //    _panel.Children.Clear();
        //    foreach (var user in _repository.GetAll().Where(user => user.LastName.ToLowerInvariant() == firstName).ToList())
        //    {
        //        AddUserToStackPanel(user);
        //    }
        //    _panel.Focus();
        //    _panel.BringIntoView();
        //}
        //private void FindByFirstAndLastName_Clicked(object sender, RoutedEventArgs e)
        //{
        //    var firstName = firstNameTextBox.Text.ToLowerInvariant();
        //    var lastName = lastNameTextBox.Text.ToLowerInvariant();
        //    _panel.Children.Clear();
        //    foreach (var user in _repository.GetAll().Where(user => user.FirstName.ToLowerInvariant() == firstName && user.LastName.ToLowerInvariant() == lastName).ToList())
        //    {
        //        AddUserToStackPanel(user);
        //    }
        //    _panel.Focus();
        //    _panel.BringIntoView();
        //}
        //private void FindByEmail_Clicked(object sender, RoutedEventArgs e)
        //{
        //    var email = emailTextBox.Text.ToLowerInvariant();
        //    _panel.Children.Clear();
        //    foreach (var user in _repository.GetAll().Where(user => user.Email.ToLowerInvariant() == email).ToList())
        //    {
        //        AddUserToStackPanel(user);
        //    }
        //    _panel.Focus();
        //    _panel.BringIntoView();
        //}
        //private void OnLoad(object sender, RoutedEventArgs e)
        //{
        //}

        //private void AddUserToStackPanel(User user)
        //{
        //    foreach (var control in AddStackPanelEntry(user!))
        //    {
        //        _ = _panel.Children.Add(control.Item1);
        //        _ = _panel.Children.Add(control.Item2);
        //    }
        //}

        //private static List<(Label, TextBlock)> AddStackPanelEntry(User user)
        //{
        //    var clientID = CreateLableWithTextBlock("Client ID", user.ClientId.ToString());
        //    var firstName = CreateLableWithTextBlock("First Name", user.FirstName);
        //    var lastName = CreateLableWithTextBlock("Last Name", textBlockText: user.LastName);
        //    var email = CreateLableWithTextBlock("Email", user.Email);
        //    var isBusinessContact = CreateLableWithTextBlock("Is a Business Contact", textBlockText: user.IsBusinessContact.ToString());
        //    var isAccountingContact = CreateLableWithTextBlock("Is a Accounting Contact", user.IsAccountingContact.ToString());
        //    var isTechnicalContact = CreateLableWithTextBlock("Is a Technical Contact", user.IsTechnicalContact.ToString());
        //    var hasApiAccess = CreateLableWithTextBlock("Has Api Access", textBlockText: user.HasApiAccess.ToString());
        //    return new List<(Label, TextBlock)> { clientID, firstName, lastName, email, isBusinessContact, isAccountingContact, isTechnicalContact, hasApiAccess };
        //}
    }
}
