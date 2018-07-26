using System;
namespace LojaInfo.Models.Dominio
{
    public class Pedido
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public DateTime DataPedido { get; set; }

        public Pedido()
        {
            
        }
        public Pedido(int id, int idcliente, DateTime datapedido)
        {
            this.Id = id;
            this.IdCliente = idcliente;
            this.DataPedido = datapedido;
        }
    }
}








