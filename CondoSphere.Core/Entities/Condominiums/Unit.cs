namespace CondoSphere.Core.Entities.Condominiums
{
    /// <summary>
    /// Represents a single unit or fraction within a Condominium,
    /// such as an apartment, office, or storage space.
    /// </summary>
    public class Unit : IEntity
    {
        /// <summary>
        /// The unique primary key for the Unit.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// A user-friendly identifier for the unit, such as "Apt 101", "Fraction A", or "Floor 2, Office 3".
        /// This is the name displayed in the UI.
        /// </summary>
        public string Identifier { get; set; } = string.Empty;

        /// <summary>
        /// The foreign key linking this Unit to its parent Condominium.
        /// This is a required field, as a Unit cannot exist without being part of a Condominium.
        /// </summary>
        public int CondominiumId { get; set; }

        /// <summary>
        /// The foreign key to the company that manages this unit's condominium.
        /// This is denormalized from the parent Condominium entity to allow for more
        //  efficient, tenant-scoped queries without requiring a join.
        /// </summary>
        public int CompanyId { get; set; }
    }
}
