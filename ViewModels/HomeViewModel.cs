using AutoService.Models;
using AutoService.Repository;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reactive.Linq;

namespace AutoService.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        #region Propriedades
        [Required(ErrorMessage = "The name is required.")]
        [StringLength(100, ErrorMessage = "The name length should be lower than 30.")]
        public ReactiveProperty<string> Name { get; private set; }
        public ReactiveCommand SaveCommand { get; private set; }
        public ReadOnlyReactiveCollection<MotorizedCardReaderModel> MotorizedCardReaderCollection { get; private set; }
        public ReadOnlyReactiveCollection<string> PortCollection { get; private set; }
        public ReactiveCollection<int> BautRateCollection { get; private set; }
        public ReactiveProperty<MotorizedCardReaderModel> SelectedMotorizedCardReader { get; private set; }
        #endregion

        public HomeViewModel()
        {
            var configuration = ConfigurationRepository.GetConfiguration();
            var listMCR = MotorizedCardReaderRepository.GetAll();
            var selectedMCR = listMCR.Where(m => m.IdMotorizedCardReader == configuration?.IdMotorizedCardReader).FirstOrDefault();

            SelectedMotorizedCardReader = new ReactiveProperty<MotorizedCardReaderModel>(selectedMCR);
            SelectedMotorizedCardReader.PropertyChanged += (_, e) => Save();

            Name = new ReactiveProperty<string>().SetValidateAttribute(() => Name);
            MotorizedCardReaderCollection = listMCR.ToObservable().ToReadOnlyReactiveCollection();
            BautRateCollection = new ReactiveCollection<int>() { 9600, 19200, 38400, 115200 };
            PortCollection = Observable.Range(1, 30)
                .Select(i => $"COM{i}")
                .ToReadOnlyReactiveCollection();

            SaveCommand = new[]
            {
                Name.ObserveHasErrors
            }
            .CombineLatestValuesAreAllFalse()
            .ToReactiveCommand(false)
            .WithSubscribe(Save);
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
                SnackBarMessage("Configuração atualizada!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                SnackBarMessage("Erro ao atualizar configuração!");
            }

            try
            {
                Framework.MotorizedCardReader.Instance(SelectedMotorizedCardReader.Value);
                Framework.MotorizedCardReader.Instance().MovePosition(0x2E);
                Framework.MotorizedCardReader.Instance().MovePosition(0x31);

                SnackBarMessage("Comando enviado para o dispositivo!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                SnackBarMessage("Não foi possível enviar o comando para o dispositivo!");
            }
        }
    }
}
