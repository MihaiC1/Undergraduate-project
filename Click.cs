//Cod sursa creare fire + verificare paralelism dintre rezistori

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Click : MonoBehaviour
{

    [SerializeField]
    private LayerMask clickableLayer;
    private List<GameObject> elementeLovite = new List<GameObject>();

    private static List<GameObject> fire = new List<GameObject>();

    private Vector2 pozitieUltimulClick = Vector2.zero;
    private Vector2 pozitiePrimulClick = Vector2.zero;
    private string numePrimulClick = null;
    private string numeUltimulClick = null;
    private string tagPrimulClick = null;
    private string tagUltimulClick = null;
    private Vector3 directieClick = Vector3.zero;
    Vector2 pozitieSpawn = new Vector2();
    int i = 1;

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {


            if (!EventSystem.current.IsPointerOverGameObject())
            {

                RaycastHit2D rayHit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.TransformDirection(Vector2.up), clickableLayer);

                if (i > 2)
                {
                    pozitieUltimulClick = Vector2.zero;
                    pozitiePrimulClick = Vector2.zero;

                    i = 1;
                }

                if (i == 1 && rayHit.transform.gameObject.tag.Contains("Rezistenta") || rayHit.transform.gameObject.tag.Contains("Fir") || rayHit.transform.gameObject.tag.Contains("Sursa"))
                {
                    i++;
                    pozitiePrimulClick = rayHit.point;
                    numePrimulClick = rayHit.transform.gameObject.name;
                    tagPrimulClick = rayHit.transform.gameObject.tag;
                }
                else if (i == 2)
                {
                    pozitieUltimulClick = rayHit.point;
                    numeUltimulClick = rayHit.transform.gameObject.name;
                    tagUltimulClick = rayHit.transform.gameObject.tag;
                    i++;
                }


                if (pozitiePrimulClick != Vector2.zero && pozitieUltimulClick != Vector2.zero)
                {
                    float pozitiePrimulClickPeX = pozitiePrimulClick.x;
                    float pozitieUltimulClickPeX = pozitieUltimulClick.x;

                    float pozitiePrimulClickPeY = pozitiePrimulClick.y;
                    float pozitieUltimulClickPeY = pozitieUltimulClick.y;

                    float distantaDintreClickuri = Mathf.Sqrt(Mathf.Pow((pozitieUltimulClickPeX - pozitiePrimulClickPeX), 2) + Mathf.Pow((pozitieUltimulClickPeY - pozitiePrimulClickPeY), 2));
                    directieClick = pozitieUltimulClick - pozitiePrimulClick;
                    float unghiClickuri = Mathf.Atan2(directieClick.y, directieClick.x) * Mathf.Rad2Deg - 90;
                    pozitieSpawn = new Vector2((pozitiePrimulClickPeX + pozitieUltimulClickPeX) / 2, (pozitiePrimulClickPeY + pozitieUltimulClickPeY) / 2);

                    GameObject fir = Instantiate(GameObject.Find("Fir"));

                    if (tagPrimulClick.Equals("Rezistenta") && tagUltimulClick.Equals("Rezistenta"))
                    {
                        fir.name = numePrimulClick + " - " + numeUltimulClick;
                        fire.Add(fir);
                        fir.transform.position = pozitieSpawn;
                        fir.transform.localScale = new Vector3(0.05f, distantaDintreClickuri, 1);
                        fir.transform.eulerAngles = Vector3.forward * unghiClickuri;
                    }
                    else if (tagPrimulClick.Equals("Rezistenta") || tagPrimulClick.Equals("Sursa"))
                    {

                        fir.name = numePrimulClick + " - " + "(" + pozitieUltimulClick + ")";
                        fire.Add(fir);
                        fir.transform.position = pozitieSpawn;
                        fir.transform.localScale = new Vector3(0.05f, distantaDintreClickuri, 1);
                        fir.transform.eulerAngles = Vector3.forward * unghiClickuri;
                    }

                    else if (tagUltimulClick.Equals("Rezistenta") || tagUltimulClick.Equals("Sursa"))
                    {
                        fir.name = "(" + pozitiePrimulClick + ")" + " - " + numeUltimulClick;
                        fire.Add(fir);
                        fir.transform.position = pozitieSpawn;
                        fir.transform.localScale = new Vector3(0.05f, distantaDintreClickuri, 1);
                        fir.transform.eulerAngles = Vector3.forward * unghiClickuri;
                    }

                    else
                    {

                        fir.name = pozitiePrimulClick + " - " + pozitieUltimulClick;
                        fire.Add(fir);
                        fir.transform.position = pozitieSpawn;
                        fir.transform.localScale = new Vector3(0.05f, distantaDintreClickuri, 1);
                        fir.transform.eulerAngles = Vector3.forward * unghiClickuri;
                    }

                }

            }

        }

    }


    public static List<GameObject> getListaFire()
    {
        return fire;
    }
    private static void removeFromListaFire(GameObject f)
    {
        fire.Remove(f);
    }
    public static void stergeDinListaFire(GameObject f)
    {
        removeFromListaFire(f);
    }
    public static void setListaFire(List<GameObject> lista)
    {
        fire = lista;
    }
    public static bool isParalel(GameObject r1, GameObject r2)
    {
        bool suntParalele = true;
        int elementeGasite = 0;
        foreach (GameObject f in fire)
        {
            if (f.name.StartsWith(r1.name) && f.name.EndsWith(r2.name) || f.name.EndsWith(r1.name) && f.name.StartsWith(r2.name))
            {
                suntParalele = false;

            }

        }


        return suntParalele;
    }
}



