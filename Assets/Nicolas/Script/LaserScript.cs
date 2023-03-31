using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    public float laserMaxLength = 100.0f; // longueur maximale du laser
    public LayerMask layerMask; // masque de collision pour définir les objets avec lesquels le laser peut interagir
    public string tagToHit = "Tag de l'objet à frapper";
    public Color laserColor = Color.red; // couleur du laser
    public bool blockPlayer = true; // le laser bloque-t-il le joueur ?
    public GameObject MurInvisible;
    //public GameObject MurInvisible1;
    //public GameObject MurInvisible2;
    //public GameObject MurInvisible3;

    private LineRenderer laserLine; // permet de dessiner la ligne du laser
    private RaycastHit hit; // permet de détecter les collisions
    private Transform laserHitPoint; // point d'impact du laser

    void Start()
    {
        // Créer une nouvelle ligne de rendu
        laserLine = gameObject.AddComponent<LineRenderer>();

        // Configurer les paramètres de la ligne de rendu du laser
        laserLine.material = new Material(Shader.Find("Sprites/Default"));
        laserLine.startWidth = 0.1f;
        laserLine.endWidth = 0.1f;
        laserLine.startColor = laserColor;
        laserLine.endColor = laserColor;
        laserLine.positionCount = 2;
        laserLine.SetPosition(0, transform.position);

        // Créer un objet vide pour stocker le point d'impact du laser
        laserHitPoint = new GameObject().transform;
        laserHitPoint.name = "Laser Hit Point";
    }

    void Update()
    {
        // Lancer un rayon à partir de l'origine du laser jusqu'à sa longueur maximale
        if (Physics.Raycast(transform.position, transform.forward, out hit, laserMaxLength, layerMask))
        {
            // Définir la position finale de la ligne de rendu sur le point d'impact
            laserLine.SetPosition(1, hit.point);

            // Stocker la position du point d'impact pour une utilisation ultérieure
            laserHitPoint.position = hit.point;

            // Vérifier si l'objet frappé a le tag spécifié
            if (hit.collider.gameObject.CompareTag(tagToHit))
            {
                // Empêcher le laser de se déplacer en verrouillant sa position sur l'objet touché
                //transform.position = hit.point;

                MurInvisible.SetActive(false);
                //MurInvisible1.SetActive(false);
                //MurInvisible2.SetActive(false);
                //MurInvisible3.SetActive(false);

                // Bloquer le joueur s'il est touché par le laser
                if (blockPlayer && hit.collider.gameObject.CompareTag("Player"))
                {
                    // Vérifier s'il y a un script de contrôle de personnage attaché au joueur
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
            // Si le rayon ne touche rien, définir la position finale de la ligne de rendu sur sa longueur maximale
            laserLine.SetPosition(1, transform.position + (transform.forward * laserMaxLength));

            // Réinitialiser la position du point d'impact
            laserHitPoint.position = transform.position + (transform.forward * laserMaxLength);
        }
    }
}