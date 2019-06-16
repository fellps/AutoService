using AutoService.Models;
using AutoService.Repository;
using Reactive.Bindings;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reactive.Linq;

namespace AutoService.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public ReactiveCommand SaveCommand { get; set; }
        public ReadOnlyReactiveCollection<MotorizedCardReaderModel> MotorizedCardReaderCollection { set; get; }
        public ReadOnlyReactiveCollection<string> PortCollection { set; get; }
        public ReactiveCollection<int> BautRateCollection { set; get; }
        public ReactiveProperty<string> Text { get; set; }
        public ReactiveProperty<MotorizedCardReaderModel> SelectedMotorizedCardReader { set;  get; }

        [Required(ErrorMessage = "The name is required.")]
        [StringLength(100, ErrorMessage = "The name length should be lower than 30.")]
        public ReactiveProperty<string> Name { get; set; }

        public HomeViewModel()
        {

            var configuration = ConfigurationRepository.GetConfiguration();
            var listMCR = MotorizedCardReaderRepository.GetAll();
            var selectedMCR = listMCR.Where(m => m.IdMotorizedCardReader == configuration?.IdMotorizedCardReader).FirstOrDefault();

            SelectedMotorizedCardReader = new ReactiveProperty<MotorizedCardReaderModel>(selectedMCR);

            MotorizedCardReaderCollection = listMCR.ToObservable().ToReadOnlyReactiveCollection();
            PortCollection = Observable.Range(1, 30).Select(i => $"COM{i}").ToReadOnlyReactiveCollection();
            BautRateCollection = new ReactiveCollection<int>() { 9600, 19200, 38400, 115200 };

            Name = new ReactiveProperty<string>().SetValidateAttribute(() => Name);
            Text = new ReactiveProperty<string>();

            SelectedMotorizedCardReader.PropertyChanged += (_, e) => Save();
        }

        public void Save()
        {
            try
            {
                ConfigurationRepository.InsertOrUpdate(new ConfigurationModel
                {
                    IdConfiguration = Guid.Empty,
                    IdMotorizedCardReader = SelectedMotorizedCardReader.Value.IdMotorizedCardReader
                });

                Framework.MotorizedCardReader.Instance(SelectedMotorizedCardReader.Value);

                Text.Value = "Conexão realizada com sucesso!";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Text.Value = "Não foi possível conectar ao dispositivo!";
            }

            try
            {
                Framework.MotorizedCardReader.Instance().MovePosition(0x2E);
                Framework.MotorizedCardReader.Instance().MovePosition(0x31);

                Text.Value = "Comando enviado para o dispositivo!";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Text.Value = "Não foi possível enviar o comando para o dispositivo!";
            }
        }
    }
}
