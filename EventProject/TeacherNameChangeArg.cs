namespace EventProject
{
    public class TeacherNameChangeArg:EventArgs
    {
        public string OldName { get; set; }
        public string NewName { get; set; }

        public TeacherNameChangeArg(string oldName, string newName)
        {
            OldName = oldName;
            NewName = newName;
        }
    }
}
