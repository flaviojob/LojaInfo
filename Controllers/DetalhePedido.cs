using LojaInfo.Models.Dominio;
using LojaInfo.Models.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace LojaInfo.Controllers
{
    public class DetalhePedidoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult FormCadastro(){
            return View();
        }
        /* O método Cadastro foi requisitado pelo formulário (FormCadastro) para cadastrar os dados.
        O formulário envia os dados com o método Post. Portanto o método Cadastro deve ser anotado como HttpsPost. */
        [HttpPost]
        public IActionResult Cadastro(DetalhePedido detalhepedido) 
        { 
        /* Comandos que serão referenciado da camada models(Modelo de dados).
            Instânciamos a classe CRUDCliente, pois esta possui os métodos responsaveis pelo cadastro,
            atualização e deleção de dados. Foi usado o método cadastro e pssando o objeto cliente com 
            os dados vindos do formulário */

        CRUDDetalhePedido c = new CRUDDetalhePedido();
        c.Cadastro(detalhepedido);
        
        return RedirectToAction("Index");
        }
        public IActionResult Atualizar()
        {
            /* Comandos que serão referenciado da camada models(Modello de dados) */
            return View();
        }
        public IActionResult Deletar()
        {
            /* Comandos que serão referenciado da camada models(Modello de dados) */
            return View();
        }
        public IActionResult Listar()
        {
            /* Comandos que serão referenciado da camada models(Modello de dados) */
            return View();
        }
        public IActionResult Listar(int id)
        {
            /* Comandos que serão referenciado da camada models(Modello de dados) */
            return View();
        }
        
    
    
    
    }
}