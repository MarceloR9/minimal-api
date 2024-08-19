using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace minimal_api.Dominio.ModelViews
{
    public struct Home
    {
        public string Mensagem {get => "Bem Vindo!";}
        public string Doc {get => "/swagger";}
    }
}