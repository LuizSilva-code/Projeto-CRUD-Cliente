﻿using CrudCliente.Domain.Enumerators;
using System.ComponentModel.DataAnnotations;

namespace CrudCliente.Applications.DTO
{
    public class EnderecoDTO
    {
        public int Id { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public int ClienteId { get; set; }
        public string Estado { get; set; }
        public string Logradouro { get; set; }
        public string Nome { get; set; }
        public string Numero { get; set; }
        public string? Observacoes { get; set; }
        public string Pais { get; set; }
        public TipoEndereco TipoEndereco { get; set; }
        public TipoLogradouro TipoLogradouro { get; set; }
        public TipoResidencia TipoResidencia { get; set; }



    }
}
