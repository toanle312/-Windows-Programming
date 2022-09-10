using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RandomEnglish
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        List<string> _images;
        List<string> _vocabularies;

        int _countReset = 0;

        int[] _used = new int[20] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        private void setupData()
        {
            _images = new List<string>()
            {
                "/Image/animal1.jpg",
                "/Image/animal2.jpg",
                "/Image/animal3.jpg",
                "/Image/animal4.jpg",
                "/Image/animal5.jpg",
                "/Image/animal6.jpg",
                "/Image/animal7.jpg",
                "/Image/animal8.jpg",
                "/Image/animal9.jpg",
                "/Image/animal10.jpg",
                "/Image/animal11.jpg",
                "/Image/animal12.jpg",
                "/Image/animal13.jpg",
                "/Image/animal14.jpg",
                "/Image/animal15.jpg",
                "/Image/animal16.jpg",
                "/Image/animal17.jpg",
                "/Image/animal18.jpg",
                "/Image/animal19.jpg",
                "/Image/animal20.jpg"
            };

            _vocabularies = new List<string>()
            {
                "Dog (dɒg): Con chó",
                "Cat (kæt): Con mèo",
                "Camel (ˈkæməl): Con lạc đà",
                "Cow (kaʊ): Con bò",
                "Turkey (ˈtɜːki): Con gà Tây ",
                "Dove (dəv): Con chim bồ câu",
                "Duck (dək): Con vịt",
                "Parrot (pærət): Con vẹt",
                "Jaguar (ˈjaɡˌwär): Con báo đốm",
                "Fox (fɒks): Con cáo",
                "Lion (ˈlaɪən): Con sư tử",
                "Bear (beə): Con gấu",
                "Elephant (ˈɛlɪfənt): Con voi",
                "Squirrel (ˈskwɪrəl): Con sóc",
                "Porcupine (ˈpɔːkjʊpaɪn): Con nhím",
                "Hippopotamus (ˌhɪpəˈpɒtəməs): Con hà mã",
                "Raccoon (rəˈkuːn): Con gấu mèo",
                "Giraffe (ʤɪˈrɑːf): Con hươu cao cổ",
                "Rhinoceros (raɪˈnɒsərəs): Con tê giác",
                "Wolf (wʊlf): Con chó sói"
            };
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            setupData();

            nextWord();
        }
        private void showButton_Click(object sender, RoutedEventArgs e)
        {
            nextWord();
        }
        private void nextWord()
        {
            var rng = new Random();

            int index = rng.Next(0, _images.Count);

            while (_used[index] > 0)
            {
                index = rng.Next(0, _images.Count);
            }

            string vocabulary = _vocabularies[index];
            vocabularyLabel.Content = vocabulary;

            var bitmap = new BitmapImage(
                new Uri(_images[index], UriKind.Relative)
            );

            vocabularyImage.Source = bitmap;

            _used[index]++;
            _countReset++;

            if(_countReset == 20)
            {
                for(int i= 0; i < 20; i++)
                {
                    _used[i] = 0;
                }
            }
        }
    }
}
