using ProjetoFinanceiro.Services.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoFinanceiro.Testes
{
    public class AppTestePrincipal
    {
        private readonly RepositorioTeste _repositorioTeste;
        private readonly ServicoTeste _servicoTeste;

        public AppTestePrincipal(RepositorioTeste repositorioTeste, ServicoTeste servicoTeste)
        {
            _repositorioTeste = repositorioTeste;
            _servicoTeste = servicoTeste;
        }

        public void Execute()
        {
            //ValidarCamadaDominio();
            //ValidarCamadaContext();
            //ValidarCamadaRepositorio();
            ValidarCamadaServico();
        }

        private void ValidarCamadaContext()
        {
            FakeContextTeste teste = new FakeContextTeste();
            teste.Execute();
            
        }

        private void ValidarCamadaDominio()
        {
            DominiosTeste teste = new DominiosTeste();
            teste.Execute();
            
        }

        private void ValidarCamadaRepositorio()
        {
            _repositorioTeste.Execute();
        }

        private void ValidarCamadaServico()
        {
            _servicoTeste.Execute();
        }

    }
}
