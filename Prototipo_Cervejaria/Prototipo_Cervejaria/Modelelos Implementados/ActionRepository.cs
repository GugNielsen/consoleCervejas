using System;
using System.Collections.Generic;
using System.Linq;

namespace Prototipo_Cervejaria.ModelelosImplementados
{
    public class ActionRepository
    {
        #region Variaveis de ActionRepository
        public double valor_total { get; set; }

        // A lista Obrigatoriamente tem ser setada com "= new List" para flopar os itens.
        public List<StoqueUser> StoqueList { get; set; } = new List<StoqueUser>();
        public List<Produto> ProdutosList { get; set; } = new List<Produto>();

        bool IsOpen = false;
        bool IsConsumo = false;
        #endregion

        /// <summary>
        /// Construtor da Classe
        /// </summary>
        public ActionRepository()
        {
        }

        /// <summary>
        /// Carrega a Lista de produtos 
        /// </summary>
        public void LoadListProdutos()
        {
            // Caso a Lista de produtos esteva cheia 
            if (ProdutosList.Count !=0)
            {
                // limpa a Lista para carrega Os mesmo dados Novamente 
                ProdutosList.Clear();
            }

            #region Setando A Lista Mook de Produtos para o repositorio 
            // Criando as Variavel mook e setendo Lista de Repositorio 
            var Skol = new Produto
            {
                cod = 1,
                Cerveja_Name = "Skol",
                Valor = 4.5,
            };

            // Criando as Variavel mook e setendo Lista de Repositorio 
            var Brahma = new Produto
            {
                cod = 2,
                Cerveja_Name = "Brahma",
                Valor = 3.9,
            };

            // Criando as Variavel mook e setendo Lista de Repositorio 
            var Itaipava = new Produto
            {
                cod = 3,
                Cerveja_Name = "Itaipava",
                Valor = 2.1,
            };

            // Criando as Variavel mook e setendo Lista de Repositorio 
            var Imperio = new Produto
            {
                cod = 4,
                Cerveja_Name = "Imperio",
                Valor = 3.0,
            };

            // Criando as Variavel mook e setendo Lista de Repositorio 
            var Skin = new Produto
            {
                cod = 5,
                Cerveja_Name = "Nova Skin",
                Valor = 1.8,
            };
            #endregion

            #region Adicionando Produtos na Lista 
            ProdutosList.Add(Skin);
            ProdutosList.Add(Skol);
            ProdutosList.Add(Itaipava);
            ProdutosList.Add(Brahma);
            ProdutosList.Add(Imperio);
            #endregion

            // Ordenando a Lista Por Ordem Numerica cresente 
            ProdutosList = ProdutosList.OrderBy(x => x.cod).ToList();
            
        }

        /// <summary>
        ///  addStoqueList
        /// </summary>
        public void addStoqueList()
        {
            // adicionar Produto na Lista chando o metedo da linha 30
            LoadListProdutos();
            // Limpando o Console 
            Console.Clear();
            // Criando um loop da variavel IsOpen
            while (IsOpen == true)
            {
                // para cada Item no Prodruto da Lista 
                foreach (var item in ProdutosList)
                {
                    // Aparecer a  Item na tela
                    Console.WriteLine(item);
                }
                // instanciando novo produto x para consulta 
                Produto x = new Produto();
                // saida de dados
                Console.WriteLine("Digite o Numero do codigo do Produto que deseja ");
                // entrada de dados Codigo para Buscar o item
                int Codigo = int.Parse(Console.ReadLine());
                // Limpando o Console 
                Console.Clear();
                // x vai verificar  o primeiro produto na ProdutosList que tenha o codigo selecionaodo e vai filtra
                // contatenando ao item
                x = ProdutosList.FirstOrDefault(c => c.cod.Equals(Codigo));

                // se x for igual a Nulo
                if (x == null)
                {
                    // voltara para linha 97
                    Console.WriteLine("O Número do código selecionado e inexistente ");
                    Console.WriteLine("Digite qualquer tecla para voltar");
                    Console.ReadKey();
                    addStoqueList();
                }
                // caso x ñ seja nula

                // Apareecera na tela 
                Console.WriteLine(x);
                // indo para um Metodo Privado
                // Passando x e Cogido como parametros
                QunatidadeStoque(x,Codigo);
            }
        }

        // continando a linha 141
        void QunatidadeStoque(Produto x, int Codigo)
        {
            // saida de dados 
            Console.WriteLine("Digite a Quantidade que deseja Compra:");
            // entrada de dados (    QUANTIDADE   )
             int quantidade = int.Parse(Console.ReadLine());
            // criando uma variavel de StoqueUser  para Filtro
            StoqueUser _stokeIten = new StoqueUser();
            //_stokeIten vai consultar o se ja tem o item na lista pelo codigo
            _stokeIten = StoqueList.FirstOrDefault(c => c.cod.Equals(Codigo));

            // se _stokeIten for null
            if (_stokeIten == null)
            {
                // Conta Matematica Valor total = Valor X quantidade 
             valor_total = x.Valor * quantidade;
              // saida de dados 
            Console.WriteLine("Valor Total da Compra  é " + valor_total + " R$");
                // saida de dados 
            Console.WriteLine("Confrimar a Compra 1/ sim ou  2/ não");
                // Entrada de dados  de dados ( VALID )
                int valid = int.Parse(Console.ReadLine());
                Console.WriteLine("Digite Qualque tecla para seguir ");
                Console.ReadKey();
                // se  Valid for 1
                if (valid == 1)
                {
                    // cria nova variavel de StoqueUser
                    var stk = new StoqueUser
                    {
                        cod = x.cod,
                        Cerveja_Name = x.Cerveja_Name,
                        Quantidade = quantidade,
                        ValorTotal_Stoque = valor_total,
                        Valor = x.Valor
                    };
                    // adiciona na lista de Stoque User 
                    StoqueList.Add(stk);
                    // Volta para Validadeted na Linha 258
                    Validadeted();
                }
                // se Valid for igual a 2
                else if (valid == 2)
                {
                    // Volta para Validadeted na Linha 258
                    Validadeted();
                }
                else
                {
                    // Saida de dados 
                    Console.WriteLine("Comando não econtrado ");
                    // Saida de dados 
                    Console.WriteLine(" Voltaremos ao menu");
                    // Saida de dados 
                    Console.WriteLine(" Digite qualque tecla para reniciar ");
                    Console.ReadKey();
                   // Validadeted();
                }
            }
            // caso  ja Stk exista com o mesmo codigo para não adicionar dois itens com mesmo codigo  
            else
            {
                // Conta  Matematica
                //Neste caso a Quantidade Total é somas das quantidades
                // Tanto setada agora na linha 149 + a quantidade ja existe no item _stokeIten
                var quantidade_total = quantidade + _stokeIten.Quantidade;
                // Valor Total é valor do Produto X quantidade Total
                valor_total = x.Valor * quantidade_total;
                // saida de dados
                Console.WriteLine("Valor Total da Compra  é " + valor_total + " R$");
                // saida de dados
                Console.WriteLine("Confrimar a Compra 1/ sim ou  2/ não");
                // entrada de dados
                int valid = int.Parse(Console.ReadLine());
                // se  Valid for 1
                if (valid == 1)
                {
                    // cria nova variavel de StoqueUser
                    var stk = new StoqueUser
                    {
                        // Concateando os item Os itens
                        cod = x.cod,
                        Cerveja_Name = x.Cerveja_Name,
                        Quantidade = quantidade_total,
                        ValorTotal_Stoque = valor_total,
                        Valor = x.Valor
                    };
                    // Deletar na lista de Stoque User 
                    StoqueList.RemoveAll(c => c.cod.Equals(Codigo));
                    // adiciona na lista de Stoque User 
                    StoqueList.Add(stk);
                    //  Voltar A Validadeted linha 258
                    Validadeted();
                }

                else if (valid == 2)
                {
                    //  Voltar A Validadeted linha 258
                    Validadeted();
                }
                else
                {
                    // Saida de dados 
                    Console.WriteLine("Comando não econtrado ");
                    // Saida de dados 
                    Console.WriteLine(" Voltaremos ao menu");
                    // Saida de dados 
                    Console.WriteLine(" Digite qualque tecla para reniciar ");
                    Console.ReadKey();
                    // Validadeted();
                }
            }
        }
        // Quando no Menu Digitar Numero 1 caira no Validadeted
        public void Validadeted()
        {  
            // Limpando o Console 
            Console.Clear();
            // Saida de dados
            Console.WriteLine("Deseja add um novo no stoque 1/ sim ou  2/ não");
            // entrada de dados (VALID)
            int valid = int.Parse( Console.ReadLine());
            // SE valid for 1
            if (valid == 1)
            {
                // IsOpen estara Aberto para continuar o loop
                IsOpen = true;
                // ira para Metedo Linha 97
                addStoqueList();
            }
            else if (valid ==2)
            {
                // termina o Loop e volta para menu
                IsOpen = false;
            }
            else
            {
                // volta para validação
                Console.WriteLine("Cliquer Qualquer Tecla e Digite 1/ ou 2");
                Console.ReadKey();
                Validadeted();
            }
        }

        private void ConsumoStoqueList()
        {
            // limpa o Console
            Console.Clear();
            // Ordena a Lista de StoqueList por orden Numerica crescente
            StoqueList = StoqueList.OrderBy(x => x.cod).ToList();
            // para cada Item na Lista StoqueList
            foreach (var item in StoqueList)
            {
                // Aparece na Tela
                Console.WriteLine(item);

            }
            // loop
            while (IsConsumo == true)
            {
                // saida de dados
                Console.WriteLine("Digite o Numero do codigo do Produto que deseja ");
                // entrada de dados para Consulta
                int Codigo = int.Parse(Console.ReadLine());
                // Criando outra objeto de Stoque User para Colsultado
                StoqueUser  stk = new StoqueUser();
                // Verificando se tem Item com o mesmo codigo na lista de Stoque List
                stk = StoqueList.FirstOrDefault(c => c.cod.Equals(Codigo));
                if (stk == null)
                {
                    #region Comando Invalido 
                    // Limpar Console 
                    Console.Clear();
                    // Saida de dados
                    Console.WriteLine("Comando Invalido ");
                    Console.WriteLine();
                    // Saida de dados
                    Console.WriteLine("Tente Novamente, Aperte Qualquer Tecla para Continuar ");
                    Console.ReadKey();
                    #endregion
                     // Voltar para Metodo da linha 288
                    ConsumoStoqueList();
                }
                // Caso Stk nao sena nulo

                // Limpar o Console
                Console.Clear();
                // Saida de Dados com STk no Consle
                Console.WriteLine(stk);
                // Saida de Dados
                Console.WriteLine("Digite a quantidade que voce bebeu: ");
                // entrada de dados (   QUANTIDADE BEBIDA)
                int quantidade_bebida = int.Parse(Console.ReadLine());
                // Se no Stoque Tive Menos que a quantidade bebida 
                if (stk.Quantidade< quantidade_bebida)
                {
                    // saida de Dados
                    Console.WriteLine("Impossivel Beber mais que quantidade stoque do usuario ");
                    // Ir para metodo do da linha 371
                    IsConsumindoStoke();
                }
                #region Conta Matematica
                
                var QuantidadeTotalStoque = stk.Quantidade - quantidade_bebida;
                var ValorCredito = stk.Valor * QuantidadeTotalStoque;
                // Um Novo Item para Para Update
                var Upd_stk = new StoqueUser
                {
                    Cerveja_Name = stk.Cerveja_Name,
                    cod = stk.cod,
                    Quantidade = QuantidadeTotalStoque,
                    ValorTotal_Stoque = ValorCredito,
                };
                // Removendo  da Lista o Item ja existe pelo Codigo
                StoqueList.RemoveAll(c => c.cod.Equals(Codigo));
                // add  o Item Atualiado
                StoqueList.Add(Upd_stk);
                // VOltando para metodo  da linha 270
                IsConsumindoStoke();
                #endregion
            }
            Console.WriteLine("Digite Qualquer Teclar");
            Console.ReadKey();
            }

        // sera usado quando no menu do programa o user digitar 3
        public void IsConsumindoStoke()
        {
            //  Limpar Console
            Console.Clear();
            // Saida de Dados
            Console.WriteLine("Deseja Consumir um item do stoque 1/ sim ou  2/ não");
            // Entrada de Dados
            int valid = int.Parse(Console.ReadLine());
            // Se Valid for 1
            if (valid == 1)
            {
                IsConsumo = true;
                // Indo para Metodo da Linha 288
                ConsumoStoqueList();
            }
            else if (valid == 2)
            {
                IsConsumo = false;
                // volta para  97 
            }
            else
            {
                // saida de dados
                Console.WriteLine("Cliquer Qualquer Tecla e Digite 1/ ou 2");
                Console.ReadKey();
                // Voltando para Metodo da linha 370
                IsConsumindoStoke();
            }
        }

        //  Menu Quando User Digita 2
        public void VerificarStoque()
        {
            // Limapr Console
            Console.Clear();
            // Se StoqueLista esta vazia
            if (StoqueList.Count == 0)
            {
                // saida de dados
                Console.WriteLine("O Stoque está Vazio ");
                Console.WriteLine();
                Console.WriteLine("Cliquer Qualquer Tecla para sair");
                Console.ReadKey();
                return;
            }
            // caso  Lista este com pelo menos um item

            // para cada item da Lista 
            foreach (var item in StoqueList)
            {
                // saida de Dados
                Console.WriteLine(item);
             
            }
            // Quebra Linha
            Console.WriteLine();
            // saida de dados
            Console.WriteLine("Digite Qualquer teclar para Volta ao Menu");
            Console.ReadKey();
        }
    }
 }

