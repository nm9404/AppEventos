package md5ec4caa34753a12429bcec816513a23c6;


public class TouchListener
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.view.View.OnTouchListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onTouch:(Landroid/view/View;Landroid/view/MotionEvent;)Z:GetOnTouch_Landroid_view_View_Landroid_view_MotionEvent_Handler:Android.Views.View/IOnTouchListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("Eventos.Utility.TouchListener, Eventos, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", TouchListener.class, __md_methods);
	}


	public TouchListener () throws java.lang.Throwable
	{
		super ();
		if (getClass () == TouchListener.class)
			mono.android.TypeManager.Activate ("Eventos.Utility.TouchListener, Eventos, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public TouchListener (android.view.View p0, md57d48028210a74cfc400f128edb466453.GalleryDetailFragment p1) throws java.lang.Throwable
	{
		super ();
		if (getClass () == TouchListener.class)
			mono.android.TypeManager.Activate ("Eventos.Utility.TouchListener, Eventos, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Views.View, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Eventos.Fragments.GalleryDetailFragment, Eventos, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", this, new java.lang.Object[] { p0, p1 });
	}


	public boolean onTouch (android.view.View p0, android.view.MotionEvent p1)
	{
		return n_onTouch (p0, p1);
	}

	private native boolean n_onTouch (android.view.View p0, android.view.MotionEvent p1);

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
