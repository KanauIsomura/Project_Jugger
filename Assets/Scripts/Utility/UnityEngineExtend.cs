using UnityEngine;
using System.Collections;

public static class UnityEngineExtend{
	//_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
	//Transformクラス
	//_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
	public static void SetPositionX(this Transform me, float val){
		Vector3 newPos = me.transform.position;
		newPos.x = val;
		me.transform.position = newPos;
	}
	public static void SetPositionY(this Transform me, float val){
		Vector3 newPos = me.transform.position;
		newPos.x = val;
		me.transform.position = newPos;
	}
	public static void SetPositionZ(this Transform me, float val){
		Vector3 newPos = me.transform.position;
		newPos.x = val;
		me.transform.position = newPos;
	}
	
	//_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
	//Matrix4x4クラス
	//_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/
	//各行のゲッター
	public static Vector3 GetRight(this Matrix4x4 me){
		return new Vector3(me.m00, me.m01, me.m02);}
	public static Vector3 GetUp(this Matrix4x4 me){
		return new Vector3(me.m10, me.m11, me.m12);}
	public static Vector3 GetForward(this Matrix4x4 me){
		return new Vector3(me.m20, me.m21, me.m22);}
	public static Vector3 GetPosition(this Matrix4x4 me){
		return new Vector3(me.m30, me.m31, me.m32);}
	//各行のセッター
	public static void SetRight(this Matrix4x4 me, Vector3 right){
		me.m00 = right.x; me.m01 = right.y; me.m02 = right.z;}
	public static void SetUp(this Matrix4x4 me, Vector3 up){
		me.m10 = up.x; me.m11 = up.y; me.m12 = up.z;}
	public static void SetForward(this Matrix4x4 me, Vector3 forward){
		me.m20 = forward.x; me.m21 = forward.y; me.m22 = forward.z;}
	public static void SetPosition(this Matrix4x4 me, Vector3 position){
		me.m30 = position.x; me.m31 = position.y; me.m32 = position.z;}

	public static void LockAt(this Matrix4x4 me, Vector3 Position){
		Vector3 VecX, VecY, VecZ;
		VecY = me.GetUp();
		VecZ = Position - me.GetPosition();

		//Z軸ベクトルの正規化
		VecZ.Normalize();

		//X軸の方向ベクトルを求める
		VecX = Vector3.Cross(VecY, VecZ);
		//X軸ベクトルの正規化
		VecX.Normalize();

		//Y軸の方向ベクトルを求める
		VecY = Vector3.Cross(VecZ, VecX);
		//Y軸ベクトルの正規化
		VecY.Normalize();

		//軸を格納する
		me.SetRight(VecX);
		me.SetUp(VecY);
		me.SetForward(VecZ);
	}
}
