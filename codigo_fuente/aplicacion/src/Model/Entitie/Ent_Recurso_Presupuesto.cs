namespace Model.Entitie
{
    public class Ent_Recurso_Presupuesto
    {
        public int DRP_Id { get; set; }
        public decimal? DRP_Precio { get; set; }
        public Ent_Presupuesto? ePresupuesto { get; set; } = new();
        public Ent_Recurso? eRecurso { get; set; } = new();
    }
}
