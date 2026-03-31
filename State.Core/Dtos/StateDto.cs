namespace State.Core.Dtos
{
    public sealed class StateDto
    {
        public StateDto(int id, string name, string code)
        {
            Id = id;
            Name = name;
            Code = code;
        }

        public int Id { get; }
        public string Name { get; }
        public string Code { get; }
    }
}