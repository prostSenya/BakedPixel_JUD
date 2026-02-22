namespace Infrastructure.Scopes
{
	public class ProjectScope : CustomScope
	{
		protected override void Awake()
		{
			base.Awake();
			DontDestroyOnLoad(this);
		}
	}
}