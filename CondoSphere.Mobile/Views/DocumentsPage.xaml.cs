using CondoSphere.Mobile.ViewModels;
using CondoSphere.Core.DTOs.Condominiums;

namespace CondoSphere.Mobile.Views;

public partial class DocumentsPage : ContentPage
{
    private readonly DocumentsViewModel _viewModel;

    public DocumentsPage(DocumentsViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
        _viewModel = vm;

        // Find the CollectionView to attach the event handler
        var collectionView = this.FindByName<CollectionView>("documentsCollectionView"); // Give your CV an x:Name
        if (collectionView != null)
        {
            collectionView.SelectionChanged += OnDocumentSelected;
        }
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.LoadDataCommand.Execute(null);
    }

    private void OnDocumentSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is DocumentDto selectedDocument)
        {
            _viewModel.OpenDocumentCommand.Execute(selectedDocument);
            // De-select the item
            (sender as CollectionView).SelectedItem = null;
        }
    }
}