using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace OPCBusinessSolution.Models;

public partial class Mbpedimento
{
    [DisplayName("#")]
    public int Id { get; set; }

    [DisplayName("CLIENTE")]
    public string Cliente { get; set; } = null!;

    [DisplayName("CLAVE PEDIMENTO")]
    public string? ClavePedimento { get; set; }

    [DisplayName("TIPO OPERACION")]
    public bool TipoOperacion { get; set; }

    [DisplayName("REFERENCIA")]
    public string Referencia { get; set; } = null!;

    [DisplayName("PEDIMENTO")]
    public string? Pedimento { get; set; }

    [DisplayName("REMESA")]
    public string? Remesa { get; set; }
    
    [DisplayName("CAJA")]
    public string? Caja { get; set; }

    [DisplayName("SELLO")]
    public string? Sello { get; set; }

    [DisplayName("DODA")]
    public string? Doda { get; set; }

    [DisplayName("CP FOLIOS")]
    public string? Cpfolios { get; set; }

    [DisplayName("CRUCE/ SOIA")]
    public string? CruceSoia { get; set; }

    [DisplayName("USUARIO")]
    public string Usuario { get; set; } = null!;

    [DisplayName("TIEMPO RECIBO BGTS")]
    public DateTime TiempoReciboBgts { get; set; }

    [DisplayName("TIEMPO ACG CONFIRMADO")]
    public DateTime? TiempoAcgconfirmado { get; set; }

    [DisplayName("FECHA CCP")]
    public DateTime? FechaCcp { get; set; }

    [DisplayName("FECHA DE REMESA")]
    public DateTime? FechaRemesa { get; set; }
}
