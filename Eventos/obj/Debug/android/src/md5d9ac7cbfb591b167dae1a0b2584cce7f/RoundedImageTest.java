package md5d9ac7cbfb591b167dae1a0b2584cce7f;


public class RoundedImageTest
	extends android.support.v7.app.ActionBarActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("Eventos.RoundedImageTest, Eventos, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", RoundedImageTest.class, __md_methods);
	}


	public RoundedImageTest () throws java.lang.Throwable
	{
		super ();
		if (getClass () == RoundedImageTest.class)
			mono.android.TypeManager.Activate ("Eventos.RoundedImageTest, Eventos, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}