using System.Collections.Generic;

namespace aec_webapi_entity_framework.Apresentacao
{
  public class HomeView
  {
    public string Mensagem
    {
      get{ return "Olá alunos seja muito bem vindo a minha api"; }
    }
    public List<string> Endpoints
    {
      get
      { 
        return new List<string>() 
        {
          "/carros",
          "/modelos",
          "/swagger"
        };
      }
    }
  }
}