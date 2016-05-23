using UnityEngine;
using System.Collections;

public class ShaderControls : MonoBehaviour
{
	#region Variables
    Vector2 Offset_cp;//offset para caminho e personagem, aplica curvatura.
	Vector2 Offset_a1;//offset para agua, aplica curvatura. Shader de agua possui transparencia.
	Vector2 Offset_a2;//offset para fluxo, agua.
	Vector2 Offset_l1;//offset para lava, aplica curvatura.
	Vector2 Offset_l2;//offset para fluxo, lava.
	Vector2 Offset_c;//offset para fluxo, ceu.
	float distance;//offset distancia.
    public Material[] Mats;
    private bool mudandoDeDirecao;
    private bool direcao;
	private int curve;
	public bool shaderZero;
	
    //GameManager gm;
	#endregion

    #region MonoBehavior Functions
	/// <summary>
	/// Inicia variaveis.
	/// </summary>
    void Start()
    {
        mudandoDeDirecao = false;
        direcao = true;
		curve = 0;
		distance = 20f;
    }
	
	/// <summary>
	/// Gera efeitos de shaders.
	/// Vira a textura para esquerda, direita, cima e baixo
	/// Aplica efeitos de fluxo para agua e lava.
	/// </summary>
	//void UpdateModif()
	void Update()
    {		
		//efeito de fluxo de ceu(skybox)
		//Offset_c.x+=0f;
		/*Offset_c.x+=0.001f;
		if(Offset_c.x>1f){
			Offset_c.x=0;
		}*/
		
		//Offset_c.y+=0f;
		/*Offset_c.y+=0.001f;
		if(Offset_c.y>1f){
			Offset_c.y=0;
		}*/
		
		//efeito de fluxo de agua
		Offset_a2.y-=0.01f;
		if(Offset_a2.y<-1){
			Offset_a2.y=0;
		}
		
		//efeito de fluxo de lava
		Offset_l2.y+=0.02f;
		if(Offset_l2.y>1){
			Offset_l2.y=0;
		}   
		
		/*Offset_cp.x = Offset_cp.y = 0;
        Offset_a1.x = Offset_a1.y = 0;
        Offset_l1.x = Offset_l1.y = 0;
        foreach (Material M in Mats)
        {
            M.SetVector("_QOffset_cp", Offset_cp);
            M.SetVector("_QOffset_a1", Offset_a1);
            M.SetVector("_QOffset_l1", Offset_l1);
        }*/
		
		foreach (Material M in Mats)
        {
			if((direcao && Offset_cp.x>-2f) || (!direcao && Offset_cp.x<2f)){
           	 	M.SetVector("_QOffset_cp",Offset_cp);
				M.SetVector("_QOffset_a1",Offset_a1);
				M.SetVector("_QOffset_l1",Offset_l1);
			}
			
			M.SetVector("_QOffset_a2",Offset_a2);
			M.SetVector("_QOffset_l2",Offset_l2);
			//M.SetVector("_QOffset_c",Offset_c);
			//M.SetFloat("_Dist", distance);
        }
    }
	#endregion
}


