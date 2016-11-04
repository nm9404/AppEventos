package md54ada4fbe4a5955f6151fa282d30cfc48;


public class FFBitmapDrawable
	extends md54ada4fbe4a5955f6151fa282d30cfc48.SelfDisposingBitmapDrawable
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_draw:(Landroid/graphics/Canvas;)V:GetDraw_Landroid_graphics_Canvas_Handler\n" +
			"n_getIntrinsicHeight:()I:GetGetIntrinsicHeightHandler\n" +
			"n_getIntrinsicWidth:()I:GetGetIntrinsicWidthHandler\n" +
			"n_setAlpha:(I)V:GetSetAlpha_IHandler\n" +
			"n_setColorFilter:(ILandroid/graphics/PorterDuff$Mode;)V:GetSetColorFilter_ILandroid_graphics_PorterDuff_Mode_Handler\n" +
			"";
		mono.android.Runtime.register ("FFImageLoading.Drawables.FFBitmapDrawable, FFImageLoading.Platform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", FFBitmapDrawable.class, __md_methods);
	}


	public FFBitmapDrawable () throws java.lang.Throwable
	{
		super ();
		if (getClass () == FFBitmapDrawable.class)
			mono.android.TypeManager.Activate ("FFImageLoading.Drawables.FFBitmapDrawable, FFImageLoading.Platform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public FFBitmapDrawable (android.content.res.Resources p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == FFBitmapDrawable.class)
			mono.android.TypeManager.Activate ("FFImageLoading.Drawables.FFBitmapDrawable, FFImageLoading.Platform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Res.Resources, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}


	public FFBitmapDrawable (android.content.res.Resources p0, android.graphics.Bitmap p1) throws java.lang.Throwable
	{
		super (p0, p1);
		if (getClass () == FFBitmapDrawable.class)
			mono.android.TypeManager.Activate ("FFImageLoading.Drawables.FFBitmapDrawable, FFImageLoading.Platform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Res.Resources, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Graphics.Bitmap, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0, p1 });
	}


	public FFBitmapDrawable (android.content.res.Resources p0, java.io.InputStream p1) throws java.lang.Throwable
	{
		super (p0, p1);
		if (getClass () == FFBitmapDrawable.class)
			mono.android.TypeManager.Activate ("FFImageLoading.Drawables.FFBitmapDrawable, FFImageLoading.Platform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Res.Resources, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:System.IO.Stream, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1 });
	}


	public FFBitmapDrawable (android.content.res.Resources p0, java.lang.String p1) throws java.lang.Throwable
	{
		super (p0, p1);
		if (getClass () == FFBitmapDrawable.class)
			mono.android.TypeManager.Activate ("FFImageLoading.Drawables.FFBitmapDrawable, FFImageLoading.Platform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Res.Resources, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:System.String, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1 });
	}


	public FFBitmapDrawable (android.graphics.Bitmap p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == FFBitmapDrawable.class)
			mono.android.TypeManager.Activate ("FFImageLoading.Drawables.FFBitmapDrawable, FFImageLoading.Platform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Graphics.Bitmap, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}


	public FFBitmapDrawable (java.io.InputStream p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == FFBitmapDrawable.class)
			mono.android.TypeManager.Activate ("FFImageLoading.Drawables.FFBitmapDrawable, FFImageLoading.Platform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "System.IO.Stream, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0 });
	}


	public FFBitmapDrawable (java.lang.String p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == FFBitmapDrawable.class)
			mono.android.TypeManager.Activate ("FFImageLoading.Drawables.FFBitmapDrawable, FFImageLoading.Platform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "System.String, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0 });
	}


	public void draw (android.graphics.Canvas p0)
	{
		n_draw (p0);
	}

	private native void n_draw (android.graphics.Canvas p0);


	public int getIntrinsicHeight ()
	{
		return n_getIntrinsicHeight ();
	}

	private native int n_getIntrinsicHeight ();


	public int getIntrinsicWidth ()
	{
		return n_getIntrinsicWidth ();
	}

	private native int n_getIntrinsicWidth ();


	public void setAlpha (int p0)
	{
		n_setAlpha (p0);
	}

	private native void n_setAlpha (int p0);


	public void setColorFilter (int p0, android.graphics.PorterDuff.Mode p1)
	{
		n_setColorFilter (p0, p1);
	}

	private native void n_setColorFilter (int p0, android.graphics.PorterDuff.Mode p1);

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
