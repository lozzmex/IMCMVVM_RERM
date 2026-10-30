using IMCMVVM_RERM.ViewModels;

namespace IMCMVVM_RERM.Views;

public partial class ImcPage : ContentPage
{
	public ImcPage()
	{
		InitializeComponent();
		//Conecta la pantalla con sus datos y comandos del viewmodel

		BindingContext = new  ImcViewModel();

	}
}