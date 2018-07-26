using System;
using System.Collections.Generic;
using System.Data;
using LojaInfo.Models.Dominio;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace LojaInfo.Models.Repositorio
{
       public class CRUDDetalhePedido : Conexao
    {
        public string Cadastro (DetalhePedido dtPedido){
            
            string mensagem = "";
            try{
                //Vamos instanciar o objeto con
                con = new MySqlConnection();
               
                //Passar o caminho e as credenciais do banco de dados.
                con.ConnectionString = local;

                //Vamos abrir a conexão
                con.Open();

                cmd = new MySqlCommand();

                //Vamos estabelecer a relação entre os comandos de Sql com o banco de dados (con)
                cmd.Connection = con;
                //Vamos definir o tipo de comando que será executado
                cmd.CommandType = CommandType.Text;

                //Escrever o comando de Sql que será exacutado

                cmd.CommandText = "insert into detalhepedido(idpedido,idproduto,quantidade)values(@idpe,@idpo,@qnt)";
                //Para evitar ataques de comandos de MySql de terceiros 
                cmd.Parameters.AddWithValue("@idpe",dtPedido.IdPedido);
                cmd.Parameters.AddWithValue("@idpo",dtPedido.IdProduto);
                cmd.Parameters.AddWithValue("@qnt",dtPedido.Quantidade);

                
                //Vamos executar a consulta de inserção

                int r = cmd.ExecuteNonQuery();
                if(r > 0)
                    mensagem = "Id do pedido cadastrado com sucesso";
                    else
                    mensagem = "Não foi possível cadastrar o id do pedido";
                //Vamos limpar o valor presente no parâmetro
                cmd.Parameters.Clear();
            }//Fim do try
            catch (MySqlException mse){
                mensagem = "Erro ao tentar cadastrar o id de pedido"+mse.Message;
            }
            catch (Exception ex){
                mensagem = "Erro Inesperado" + ex.Message;
            }
            finally
            {
                con.Close();
            }
            return mensagem;
            }

        public string Atualizar (DetalhePedido dtPedido){
            
            string mensagem = "";
            try{
                //Vamos instanciar o objeto con
                con = new MySqlConnection();
               
                //Passar o caminho e as credenciais do banco de dados.
                con.ConnectionString = local;

                //Vamos abrir a conexão
                con.Open();

                cmd = new MySqlCommand();

                //Vamos estabelecer a relação entre os comandos de Sql com o banco de dados (con)
                cmd.Connection = con;
                //Vamos definir o tipo de comando que será executado
                cmd.CommandType = CommandType.Text;

                //Escrever o comando de Sql que será exacutado

                cmd.CommandText = "update detalhepedido set idpedido=@idpe, idproduto=@idpo, quantidade=@qnt";
                //Para evitar ataques de comandos de MySql de terceiros 
                cmd.Parameters.AddWithValue("@idpe",dtPedido.IdPedido);
                cmd.Parameters.AddWithValue("@idpo",dtPedido.IdProduto);
                cmd.Parameters.AddWithValue("@qnt",dtPedido.Quantidade);
                
                //Vamos executar a consulta de inserção

                int r = cmd.ExecuteNonQuery();
                if(r > 0)
                    mensagem = "Detalhe do pedido atualizado com sucesso";
                    else
                    mensagem = "Não foi possível atualizar o detalhe do pedido";
                //Vamos limpar o valor presente no parâmetro
                cmd.Parameters.Clear();
            }//Fim do try
            catch (MySqlException mse){
                mensagem = "Erro ao tentar atualizar o detalhe do pedido"+mse.Message;
            }
            catch (Exception ex){
                mensagem = "Erro inesperado" + ex.Message;
            }
            finally
            {
                con.Close();
            }
            return mensagem;
            }

        public string Deletar(DetalhePedido dtPedido){
            
            string mensagem = "";
            try{
                //Vamos instanciar o objeto con
                con = new MySqlConnection();
               
                //Passar o caminho e as credenciais do banco de dados.
                con.ConnectionString = local;

                //Vamos abrir a conexão
                con.Open();

                cmd = new MySqlCommand();

                //Vamos estabelecer a relação entre os comandos de Sql com o banco de dados (con)
                cmd.Connection = con;
                //Vamos definir o tipo de comando que será executado
                cmd.CommandType = CommandType.Text;

                //Escrever o comando de Sql que será exacutado

                cmd.CommandText = "delete from detalhepedido where idpedido=@idpe, idproduto=@idpo, quantidade=@qnt";
                //Para evitar ataques de comandos de MySql de terceiros 
                cmd.Parameters.AddWithValue("@idpe",dtPedido.IdPedido);
                cmd.Parameters.AddWithValue("@idpo",dtPedido.IdProduto);
                cmd.Parameters.AddWithValue("@qnt",dtPedido.Quantidade);
                
                //Vamos executar a consulta de inserção

                int r = cmd.ExecuteNonQuery();
                if(r > 0)
                    mensagem = "Detalhe do prduto deletado com sucesso";
                    else
                    mensagem = "Não foi possível deletar o detalhe do produto.";
                //Vamos limpar o valor presente no parâmetro
                cmd.Parameters.Clear();
            }//Fim do try
            catch (MySqlException mse){
                mensagem = "Erro ao tentar deletar o detalhe do pedido"+mse.Message;
            }
            catch (Exception ex){
                mensagem = "Erro Inesperado" + ex.Message;
            }
            finally
            {
                con.Close();
            }
            return mensagem;
            }



                public List<DetalhePedido> Listar(){
                    List<DetalhePedido> ListarDetalhePedido = new List<DetalhePedido>();

                    try{
                        //Instanciar o objeto con
                        con = new MySqlConnection();

                        //Passar o caminho e as credenciais do banco de dados
                        con.ConnectionString = local;

                        //Abrir o banco
                        con.Open();

                        //Instanciar o objeto cmd
                        cmd = new MySqlCommand();

                        cmd.Connection = con;

                        cmd.CommandType = CommandType.Text;

                        cmd.CommandText = "select * from detalhepedido";

                        cmd.ExecuteReader();

                        //Enquanto houver dados presentes no dr deve ser executada a leitura destes dados.

                        while(dr.Read()){
                        //Capturar os dados de dr e montar um cliente para ser adicionado a lista de clientes
                        DetalhePedido dtP= new DetalhePedido();
                        dtP.Id = dr.GetInt32(0);
                        dtP.IdPedido = dr.GetInt32(1);
                        dtP.IdProduto = dr.GetInt32(2);
                        dtP.Quantidade = dr.GetInt32(3);
                        ListarDetalhePedido.Add(dtP);

                        }

                    }
                    catch(MySqlException mse){
                        throw new Exception("Erro ao tentar ler os clientes."+mse.Message);
                    }
                    finally{
                        con.Close();
                    }

                    return ListarDetalhePedido;
                }

                public List<DetalhePedido> Listar(int id){
                    List<DetalhePedido> ListarDetalhesPedidos = new List<DetalhePedido>();

                    try{
                        //Instanciar o objeto con
                        con = new MySqlConnection();

                        //Passar o caminho e as credenciais do banco de dados
                        con.ConnectionString = local;

                        //Abrir o banco
                        con.Open();

                        //Instanciar o objeto cmd
                        cmd = new MySqlCommand();

                        cmd.Connection = con;

                        cmd.CommandType = CommandType.Text;

                        cmd.CommandText = "select * from detalhepedido where id=@i";
                        cmd.Parameters.AddWithValue("@i",id);

                        cmd.ExecuteReader();

                        //Enquanto houver dados presentes no dr deve ser executada a leitura destes dados.

                        while(dr.Read()){
                        //Capturar os dados de dr e montar um cliente para ser adicionado a lista de clientes
                        DetalhePedido dtP= new DetalhePedido();
                        dtP.Id = dr.GetInt32(0);
                        dtP.IdPedido = dr.GetInt32(1);
                        dtP.IdProduto = dr.GetInt32(2);
                        dtP.Quantidade = dr.GetInt32(3);
                        ListarDetalhesPedidos.Add(dtP);

                        }

                    }
                    catch(MySqlException mse){
                        throw new Exception("Erro ao tentar ler os clientes."+mse.Message);
                    }
                    finally{
                        con.Close();
                    }

                    return ListarDetalhesPedidos;
                }


                

    }
}