using AutoService.Models;
using AutoService.Models.Enums;
using AutoService.Repository;
using Reactive.Bindings;
using System;

namespace AutoService.Business
{
    public class HomeBusiness : Business
    {
        public ReactiveProperty<string> Text { get; set; }
        public ReactiveCollection<MotorizedCardReaderModel> MotorizedCardReaderCollection { set; get; }
        public ReactiveProperty<MotorizedCardReaderModel> SelectedMotorizedCardReader { set; get; }

        internal void Save()
        {
            try
            {
                ConfigurationRepository.Insert(new ConfigurationModel
                {
                    IdConfiguration = Guid.NewGuid(),
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
            catch (Exception)
            {
                Text.Value = "Não foi possível enviar o comando para o dispositivo!";
            }
        }

        public override void InitializeComponents()
        {
            MotorizedCardReaderCollection = new ReactiveCollection<MotorizedCardReaderModel>
            {
                new MotorizedCardReaderModel { Name = "MT318V4", Port="COM2", Baut=9600, Type = MotorizedCardReaderEnum.MT318V4 }
            };

            SelectedMotorizedCardReader = new ReactiveProperty<MotorizedCardReaderModel>();

            Text = new ReactiveProperty<string>();
        }
    }
}
