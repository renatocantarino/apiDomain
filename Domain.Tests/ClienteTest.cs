using System;
using Domain.Entities;
using FluentAssertions;
using Xunit;

namespace Domain.Tests
{
    public class ClienteTest
    {
        [Fact]
        public void Erro_AO_Criar_Cliente_Vazio()
        {
            var cliente = new Cliente("" , "" , "");

            cliente.IsValid.Should().BeFalse();
            cliente.ValidationResult.Errors.Should().NotBeEmpty();
        }
        
        [Fact]
        public void SUCESSO_AO_Criar_Cliente()
        {
            var cliente = new Cliente("eu" , "voce" , "xxxxxx@gmail.com");

            cliente.IsValid.Should().BeTrue();
            cliente.ValidationResult.Errors.Should().BeEmpty();
        }
    }
}