using Microsoft.AspNetCore.Mvc;

namespace LojaInfo.Controllers
{
    public class ProdutoController:Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Cadastro()
        {
            //Comandos que serão referenciados da camada
            //Models(Modelos de dados)
            return View();

        }
        public IActionResult Atualizar()
        {
            //Comandos que serão referenciados da camada
            //Models(Modelos de dados)
            return View();
        }
        public IActionResult Deletar(){
            //Comandos que serão referenciados da camada
            //Models(Modelos de dados)
            return View();
        }
        public IActionResult Listar()
        {
            //Comandos que serão referenciados da camada
            //Models(Modelos de dados)
            return View();
        }
        public IActionResult Listar(int id)
        {
            //Comandos que serão referenciados da camada
            //Models(Modelos de dados)
            return View();
        }

}    
}