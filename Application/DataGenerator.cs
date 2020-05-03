using System.Collections.Generic;
using Application.Dtos;


namespace Application
{
    public static class DataGenerator
    {

        public static  List<ClienteDTO> getClientes()
        {
            var lista = new List<ClienteDTO>
            {
                new ClienteDTO() {Nome = "nome 1", Email = "nome@gmail.com", Sobrenome = "sobrenome1"},
                new ClienteDTO() {Nome = "nome 2", Email = "nome1@gmail.com", Sobrenome = "sobrenome2"},
                new ClienteDTO() {Nome = "nome 3", Email = "nome2@gmail.com", Sobrenome = "sobrenome3"}
            };

            return lista;
        }


        public static  List<ProdutoDTO> getProdutos()
        {
            var lista = new List<ProdutoDTO>
            {
                new ProdutoDTO() {Nome = "nome 1", Valor = 100},
                new ProdutoDTO() {Nome = "nome 2", Valor = 150},
                new ProdutoDTO() {Nome = "nome 3",Valor = 250 }
            };

            return lista;
        }


    }
}