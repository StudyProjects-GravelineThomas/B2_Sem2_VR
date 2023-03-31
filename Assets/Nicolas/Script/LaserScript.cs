using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    public float laserMaxLength = 100.0f; // longueur maximale du laser
    public LayerMask layerMask; // masque de collision pour d�finir les objets avec lesquels le laser peut interagir
    public string tagToHit = "Tag de l'objet � frapper";
    public Color laserColor = Color.red; // couleur du laser
    public bool blockPlayer = true; // le laser bloque-t-il le joueur ?
    public GameObject MurInvisible;
    //public GameObject MurInvisible1;
    //public GameObject MurInvisible2;
    //public GameObject MurInvisible3;

    private LineRenderer laserLine; // permet de dessiner la ligne du laser
    private RaycastHit hit; // permet de d�tecter les collisions
    private Transform laserHitPoint; // point d'impact du laser

    void Start()
    {
        // Cr�er une nouvelle ligne de rendu
        laserLine = gameObject.AddComponent<LineRenderer>();

        // Configurer les param�tres de la ligne de rendu du laser
        laserLine.material = new Material(Shader.Find("Sprites/Default"));
        laserLine.startWidth = 0.1f;
        laserLine.endWidth = 0.1f;
        laserLine.startColor = laserColor;
        laserLine.endColor = laserColor;
        laserLine.positionCount = 2;
        laserLine.SetPosition(0, transform.position);

        // Cr�er un objet vide pour stocker le point d'impact du laser
        laserHitPoint = new GameObject().transform;
        laserHitPoint.name = "Laser Hit Point";
    }

    void Update()
    {
        // Lancer un rayon � partir de l'origine du laser jusqu'� sa longueur maximale
        if (Physics.Raycast(transform.position, transform.forward, out hit, laserMaxLength, layerMask))
        {
            // D�finir la position finale de la ligne de rendu sur le point d'impact
            laserLine.SetPosition(1, hit.point);

            // Stocker la position du point d'impact pour une utilisation ult�rieure
            laserHitPoint.position = hit.point;

            // V�rifier si l'objet frapp� a le tag sp�cifi�
            if (hit.collider.gameObject.CompareTag(tagToHit))
            {
                // Emp�cher le laser de se d�placer en verrouillant sa position sur l'objet touch�
                //transform.position = hit.point;

                MurInvisible.SetActive(false);
                //MurInvisible1.SetActive(false);
                //MurInvisible2.SetActive(false);
                //MurInvisible3.SetActive(false);

                // Bloquer le joueur s'il est touch� par le laser
                if (blockPlayer && hit.collider.gameObject.CompareTag("Player"))
                {
                    // V�rifier s'il y a un script de contr�le de personnage attach� au joueur
                    CharacterController controller = hit.collider.gameObject.GetComponent<CharacterController>();
                    if (controller != null)
                    {
                        controller.enabled = false;
                    }
                }
            }
            else
            {
                MurInvisible.SetActive(true);
                //MurInvisible1.SetActive(true);
                //MurInvisible2.SetActive(true);
                //MurInvisible3.SetActive(true);
            }
        }
        else
        {
            // Si le rayon ne touche rien, d�finir la position finale de la ligne de rendu sur sa longueur maximale
            laserLine.SetPosition(1, transform.position + (transform.forward * laserMaxLength));

            // R�initialiser la position du point d'impact
            laserHitPoint.position = transform.position + (transform.forward * laserMaxLength);
        }
    }
}