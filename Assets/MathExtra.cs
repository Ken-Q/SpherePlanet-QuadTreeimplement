﻿using UnityEngine;
using System.Collections;

public static class MathExtra {
	
	public static Vector3 Verlet(Vector3 lxt,Vector3 xt,Vector3 a,float d = 0.2f,float dt = 0.02f)
	{
		return xt + d * (xt - lxt) + a * dt*dt;
	}
	public static float GetDegree(float d)
	{
		while (d>180f) {
			d -= 360f;
		}
		while (d<-180f) {
			d += 360f;
		}
		return d;
	}

	public static float ConstantLerp(float ori,float target,float speed)
	{
		if (target > ori) {
			return Mathf.Min (ori+speed,target);
		}
		return Mathf.Max (ori-speed,target);
	}
	public static float GetV2L(Vector2 v)
	{
		return MathExtra.FastSqrt(Mathf.Pow(v.x,2f)+Mathf.Pow(v.y,2f));
	}
	public static float GetV3L(Vector3 v)
	{
		return MathExtra.FastSqrt(v.x*v.x+v.y*v.y+v.z*v.z);
	}
	public static float FastSqrt(float x)
	{
		unsafe  
		{  
			int i;
			float x2, y;
			const float threehalfs = 1.5F;
			x2 = x * 0.5F;
			y  = x;
			i  = * ( int * ) &y;     
			i  = 0x5f375a86 - ( i >> 1 ); 
			y  = * ( float * ) &i;
			y  = y * ( threehalfs - ( x2 * y * y ) ); 
			//y  = y * ( threehalfs - ( x2 * y * y ) );  	
			//y  = y * ( threehalfs - ( x2 * y * y ) ); 
			return x*y;
		}
	}
	public static float InverseSqrtFast(float x)  
	{  
		//return OpenGLTK.MathInverseSqrtFast.InverseSqrtFast(x);  
		unsafe  
		{  
			float xhalf = 0.5f * x;  
			int i = *(int*)&x;              // Read bits as integer.  
			i = 0x5f375a86 - (i >> 1);      // Make an initial guess for Newton-Raphson approximation  
			x = *(float*)&i;                // Convert bits back to float  
			x = x * (1.5f - xhalf * x * x); // Perform left single Newton-Raphson step.  
			return x;  
		}  
	}  
	public static float Dot (Vector2 v1,Vector2 v2)
	{
		return v1.x * v2.x + v1.y * v2.y;
	}
	public static Vector2 Damping(float time,float swing,float damping,float hz){
		Vector2 pos = Vector2.zero;
		pos.x = time;
		pos.y = swing * Mathf.Pow (damping, -time) * Mathf.Sin (hz * time);
		return pos;
	}
	public static float GetDegree(Vector2 dir)
	{
		if (dir.y == 0) {
			if (dir.x > 0) {
				return 0f;
			} else {
				return 180f;
			}
		}
		float oppo = dir.y;
		float hy = dir.magnitude;
		float degree = Mathf.Asin (oppo / hy) * Mathf.Rad2Deg;
		if (dir.x < 0 && dir.y > 0)
			return 180f - degree;
		if (dir.x <= 0 && dir.y < 0)
			return 180f - degree;
		if (dir.x > 0 && dir.y < 0)
			return 360f + degree;
		return degree;
	} 
	public static bool ApproEquals(float x,float y)
	{
		if (Mathf.Abs (x - y) <= 0.1f)
			return true;
		return false;
	}
}
