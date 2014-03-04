/// <summary>
/// Model maker interface.
/// 
/// By Engamin Sanchez
/// Last Edited: 5/31/2013
/// 
/// Description:
/// 	A Unity Editor window which allows you to designate a certain pattern to create Unity Primitive
/// 	shapes. These patters could be used for level designing, 8bit style models, or any other creative design.
/// 	
/// 	As of now, it can only create a pattern in a 2D grid, so no depth yet. It can only use Unity Primitives for
/// 	now and empty GameObjects in case you need a pattern in which to designate other prefabs using empty objects.
/// 
/// </summary>





using UnityEngine;
using System.Collections;
using UnityEditor;

public class ModelMakerInterface : EditorWindow {
	//@MenuItem("Window/My Window");
	[MenuItem("ModelMaker/Make 8Bit Model")]
	
//------------------------------------------------------------
	// Show Window
    static void ShowWindow()
	{
        EditorWindow.GetWindow(typeof(ModelMakerInterface));
    }
	
	
//-----------------------------------------------------------
	// Variables
	
	private bool makeCube = false;
	private bool makeSphere = false;
	private bool makeCylinder = false;
	
	private int hSliderValue = 1;
	private int vSliderValue = 1;
	private int hModelDim = 1;
	private int vModelDim = 1;
	private int dModelDim = 1;
	private float sModelDim = 1.0f;
	private string hSliderText = "";
	private string vSliderText = "";
	private string dSliderText = "";
	private string sSliderText = "";
	
				bool toggleX = false;
	
	private ArrayList hCheckboxDim = new ArrayList();
	private ArrayList vCheckboxDim = new ArrayList();
	private ArrayList toggleBool = new ArrayList();
	
	private int shapeToolbar = 0;
	private string[] shapeToolbarStr = new string[]{"Cube", "Sphere", "Cylinder", "Capsule", "Empty Game Object"};
	
	

//-------------------------------------------------------------
	// GUI
	
    void OnGUI () {
        // The actual window code goes here	
		EditorGUILayout.BeginHorizontal();
			shapeToolbar = GUILayout.Toolbar(shapeToolbar, shapeToolbarStr);
		EditorGUILayout.EndHorizontal();
		
		GUILayout.BeginHorizontal();
			GUILayout.Label("Horizonal Dimensions: ");
			hSliderText = GUILayout.TextField(hSliderText, 2);
			GUILayout.Label("Vertical Dimensions: ");
			vSliderText = GUILayout.TextField(vSliderText, 2);
			GUILayout.Label ("Depth:");
			dSliderText = GUILayout.TextField(dSliderText, 2);
			GUILayout.Label ("Scale:");
			dSliderText = GUILayout.TextField(sSliderText, 1);
		GUILayout.EndHorizontal();
		
		GUILayout.BeginVertical();
			hSliderValue = Mathf.RoundToInt(GUILayout.HorizontalSlider(hSliderValue, 1, 50 ));
			Debug.Log(hModelDim);
			hModelDim = hSliderValue;
		GUILayout.EndVertical();
		
		GUILayout.BeginHorizontal();
			vSliderValue = Mathf.RoundToInt(GUILayout.VerticalSlider(vSliderValue, 1, 50));
			Debug.Log(vModelDim);
			vModelDim = vSliderValue;
			bool toggle = false;
		
			if(!GUI.changed)
			{
				for (int i = 0; i<hModelDim; i++)
				{
					toggleBool.Add(toggle);
					hCheckboxDim.Add(GUI.Toggle(new Rect(15.0f+(i*15.0f),70.0f,5.0f,5.0f),toggle,""));
				
					for (int j = 0; j<(vModelDim-1); j++)
					{
						// need one less row since first row is already being made by previous forloop
						toggleBool.Add(toggle);
						vCheckboxDim.Add(GUI.Toggle(new Rect(15.0f+(i*15.0f),85.0f+(j*15.0f),5.0f,5.0f),toggle,""));
					}
				}
			}
		
		GUILayout.EndHorizontal();
			
			// testing checkboxes
		GUILayout.BeginVertical();
			GUI.Toggle(new Rect(50.0f, 300.0f, 1.0f, 1.0f), toggleX,"");
		GUILayout.EndVertical();
		
			
    	GUILayout.BeginVertical();
			bool makeModel = GUILayout.Button("Make Model");
			
			if (makeModel == true)
			{
				if (shapeToolbar == 0)
					{CreateCube();}
				else if (shapeToolbar == 1)
					{CreateSphere();}
				else if (shapeToolbar == 2)
					{CreateCylinder();}
				else if (shapeToolbar == 3)
					{CreateCapsule();}
				else if (shapeToolbar == 4)
					{CreateEmptyGameobject();}
				else
					{Debug.LogError("Something is wrong with the shapes");}
			}
			else
			{Debug.Log("nothing is happening");}
			
		GUILayout.EndVertical();	
    }
	
//-------------------------------------------------------------------------------
	// Methods
	
	void CreateCube()
	{
		GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube.transform.position = new Vector3(0, 0, 0);
	}
	void CreateSphere()
	{
		GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		sphere.transform.position = new Vector3(0, 0, 0);
	}
	void CreateCylinder()
	{
		GameObject cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
		cylinder.transform.position = new Vector3(0, 0, 0);
	}
	void CreateCapsule()
	{
		GameObject capsule = GameObject.CreatePrimitive(PrimitiveType.Capsule);
		capsule.transform.position = new Vector3(0, 0, 0);
	}
	void CreateEmptyGameobject()
	{
		GameObject emptyGO = new GameObject();
		emptyGO.transform.position = new Vector3(0, 0, 0);
			
	}
}
