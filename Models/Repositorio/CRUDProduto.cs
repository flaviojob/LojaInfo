using System;
using System.Collections.Generic;
using System.Data;
using LojaInfo.Models.Dominio;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace LojaInfo.Models.Repositorio
{
       public class CRUDProduto : Conexao
    {
        public string Cadastro (Produto produto){
            
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

                cmd.CommandText = "insert into produto (nomeproduto,tipo,preco,quantidade)values(@np,@t,@p,@qnt)";
                //Para evitar ataques de comandos de MySql de terceiros 
                cmd.Parameters.AddWithValue("@np",produto.NomeProduto);
                cmd.Parameters.AddWithValue("@t",produto.Tipo);
                cmd.Parameters.AddWithValue("@p",produto.Preco);
                cmd.Parameters.AddWithValue("@qnt",produto.Quantidade);
                
                //Vamos executar a consulta de inserção

                int r = cmd.ExecuteNonQuery();
                if(r > 0)
                    mensagem = "Produto cadastrado com sucesso";
                    else
                    mensagem = "Não foi possível cadastrar o Produto";
                //Vamos limpar o valor presente no parâmetro
                cmd.Parameters.Clear();
            }//Fim do try
            catch (MySqlException mse){
                mensagem = "Erro ao tentar cadastrar o produto"+mse.Message;
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

        public string Atualizar (Produto produto){
            
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
                cmd.CommandText = "update produto set nomeproduto=np, tipo=t, preco=p, quantidade=qnt";
                
                //Para evitar ataques de comandos de MySql de terceiros 
                cmd.Parameters.AddWithValue("@np",produto.NomeProduto);
                cmd.Parameters.AddWithValue("@t",produto.Tipo);
                cmd.Parameters.AddWithValue("@p",produto.Preco);
                cmd.Parameters.AddWithValue("@qnt",produto.Quantidade);


                //Vamos executar a consulta de inserção
                int r = cmd.ExecuteNonQuery();
                if(r > 0)
                    mensagem = "Id do cliente atualizado com sucesso";
                    else
                    mensagem = "Não foi possível atualizar o id do cliente";
                //Vamos limpar o valor presente no parâmetro
                cmd.Parameters.Clear();
            }//Fim do try
            catch (MySqlException mse){
                mensagem = "Erro ao tentar atualizar o id do cliente"+mse.Message;
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

        public string Deletar(Produto produto){
            
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

                cmd.CommandText = "delete from produto where nomeproduto=@np, tipo=t, preco=p, quantidade=qnt";
                //Para evitar ataques de comandos de MySql de terceiros 
                cmd.Parameters.AddWithValue("@np",produto.NomeProduto);
                cmd.Parameters.AddWithValue("@t",produto.Tipo);
                cmd.Parameters.AddWithValue("@p",produto.Preco);
                cmd.Parameters.AddWithValue("@qnt",produto.Quantidade);
                
                //Vamos executar a consulta de inserção

                int r = cmd.ExecuteNonQuery();
                if(r > 0)
                    mensagem = "Produto deletado com sucesso";
                    else
                    mensagem = "Não foi possível deletar o produto.";
                //Vamos limpar o valor presente no parâmetro
                cmd.Parameters.Clear();
            }//Fim do try
            catch (MySqlException mse){
                mensagem = "Erro ao tentar deletar o produto"+mse.Message;
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



                public List<Produto> Listar(){
                    List<Produto> ListarProduto = new List<Produto>();

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

                        cmd.CommandText = "select * from produto";

                        cmd.ExecuteReader();

                        //Enquanto houver dados presentes no dr deve ser executada a leitura destes dados.

                        while(dr.Read()){
                        //Capturar os dados de dr e montar um cliente para ser adicionado a lista de clientes
                        Produto pr= new Produto();
                        pr.NomeProduto = dr.GetString(0);
                        pr.Tipo = dr.GetString(1);
                        pr.Preco = dr.GetDouble(2);
                        pr.Quantidade = dr.GetInt32(3);
                        ListarProduto.Add(pr);

                        }

                    }
                    catch(MySqlException mse){
                        throw new Exception("Erro ao tentar ler os clientes."+mse.Message);
                    }
                    finally{
                        con.Close();
                    }

                    return ListarProduto;
                }

                public List<Produto> Listar(int id){
                    List<Produto> ListarProdutos = new List<Produto>();

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

                        cmd.CommandText = "select * from produto where id=@i";
                        cmd.Parameters.AddWithValue("@i",id);

                        cmd.ExecuteReader();

                        //Enquanto houver dados presentes no dr deve ser executada a leitura destes dados.

                        while(dr.Read()){
                        //Capturar os dados de dr e montar um cliente para ser adicionado a lista de clientes
                        Produto pr= new Produto();
                        pr.NomeProduto = dr.GetString(0);
                        pr.Tipo = dr.GetString(1);
                        pr.Preco = dr.GetDouble(2);
                        pr.Quantidade = dr.GetInt32(3);
                        ListarProdutos.Add(pr);

                        }

                    }
                    catch(MySqlException mse){
                        throw new Exception("Erro ao tentar ler os produtos."+mse.Message);
                    }
                    finally{
                        con.Close();
                    }

                    return ListarProdutos;
                }


                

    }
}