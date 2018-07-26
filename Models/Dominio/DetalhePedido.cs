using System;

    namespace LojaInfo.Models.Dominio
    {
    public class DetalhePedido
    {
        public int Id { get; set; }
        public int IdPedido { get; set; }
        public int IdProduto { get; set; }
        public int Quantidade { get; set; }

        public DetalhePedido()
        {
            
        }
        public DetalhePedido(int id, int idpedido, int idproduto, int quantidade)
        {
            this.Id = id;
            this.IdPedido=idpedido;
            this.IdProduto = idproduto;
            this.Quantidade = quantidade;
        }
    }
}

//create database dblojainfo;
//use dblojainfo;
//create table cliente(
//id int auto_increment primary key,
//nome varchar(100) not null,
//email varchar(100) not null,
//datacadastro timestamp default current_timestamp
//);
//create table produto(
//id int auto_increment primary key,
//nomeproduto varchar(50) not null,
//tipo varchar(30) not null,
//preco decimal(10,2) not null,
//quantidade int not null default 1
//);
//create table pedido(
//id int auto_increment primary key,
//datapedido timestamp default current_timestamp,
//idcliente int not null,
//constraint `pk_cli_fk_pd` foreign key(idcliente) references cliente(id)
//);
