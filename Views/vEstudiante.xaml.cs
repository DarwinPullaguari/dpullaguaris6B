using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace dpullaguaris6B.Views;

public partial class vEstudiante : ContentPage
{
	private const string Url = "http://10.2.3.250/wsestudiantes/post.php";
	private readonly HttpClient client=new HttpClient();
	private ObservableCollection<Models.Estudiante> estud;

    public vEstudiante()
	{
		InitializeComponent();
		Listar();
	}
	public async void Listar()
	{
		var content = await client.GetStringAsync(Url);
		List<Models.Estudiante> listEst=JsonConvert.DeserializeObject<List<Models.Estudiante>>(content);
		estud=new ObservableCollection<Models.Estudiante>(listEst);
        lvEstudiantes.ItemsSource = estud;
	}
}