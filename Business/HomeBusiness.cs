using AutoService.Models;
using AutoService.Repository;
using Reactive.Bindings;
using System;
using System.Reactive.Linq;

namespace AutoService.Business
{
    public class HomeBusiness : Business
    {
        public ReactiveProperty<string> Text { get; set; }
        public ReadOnlyReactiveCollection<MotorizedCardReaderModel> MotorizedCardReaderCollection { set; get; }
        public ReactiveProperty<MotorizedCardReaderModel> SelectedMotorizedCardReader { set; get; }

        internal void Save()
        {
            try
            {
                ConfigurationRepository.InsertOrUpdate(new ConfigurationModel
                {
                    IdConfiguration = Guid.Parse("fe0fd1c8-a760-41dd-8b7d-8916b1337bc8"),
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

        public override void InitializeComponents()
        {
            var configuration = ConfigurationRepository.GetConfiguration();
            var selectedMCR = MotorizedCardReaderRepository.GetByIdMotorizedCardReader(configuration?.IdMotorizedCardReader);

            MotorizedCardReaderCollection = MotorizedCardReaderRepository.GetAll().ToObservable().ToReadOnlyReactiveCollection();
            SelectedMotorizedCardReader = new ReactiveProperty<MotorizedCardReaderModel>(selectedMCR);

            Text = new ReactiveProperty<string>();
        }
    }
}
