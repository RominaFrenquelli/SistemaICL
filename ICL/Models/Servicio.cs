﻿namespace ICL.Models
{
    public class Servicio : MiClaseBase
    {
        public string? Nombre { get; set; }
        public List<PedidoPostulante>? PedidosPostulantes { get; set; }
        
    }
}
