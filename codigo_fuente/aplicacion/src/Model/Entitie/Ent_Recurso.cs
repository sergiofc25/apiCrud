namespace Model.Entitie
{
    public class Ent_Recurso
    {
        public int Rec_Id { get; set; }
        public string? Rec_IndUnificado { get; set; }
        public string? Rec_Nombre { get; set; }
        public Ent_Tipo_Recurso eTipo_Recurso { get; set; } = new();
        public Ent_Unidad_Medida eUnidad_Medida { get; set; } = new();
        public bool Rec_Estado { get; set; }
        public Ent_Partida_Recurso? ePartida_Recurso { get; set; }
        public Ent_Recurso_Presupuesto? eRecurso_Presupuesto { get; set; }

    }
}
