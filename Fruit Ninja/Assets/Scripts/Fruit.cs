using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    [SerializeField] private GameObject _whole; //tam
    [SerializeField] private GameObject _sliced; //kesilmiş

    private Rigidbody _fruitRigidbody;
    private Collider _fruitCollider;

    private void Awake()
    {
        _fruitCollider = GetComponent<Collider>();
        _fruitRigidbody = GetComponent<Rigidbody>();
    }
    void Slice(Vector3 direction, Vector3 position, float force) //meyveyi hangi açıyla keseceğimizi ayarlayacağım yer 
    {
        _whole.SetActive(false);
        _sliced.SetActive(true);
        _fruitCollider.enabled = false; //artık kontrol etmemize gerek yok 


        //Bu satırda açıyı hesaplamak için belirlenen yönün x ve y sini tanjantını alarak radyana dönüştürmüş ve Mathf.Rad2Deg yani
        //Radian to Degree ile çarparak dereceye dönüştürmüş.(kaç derecelik açıyla bakması gerektiğini belirlemiş yani)
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        _sliced.transform.rotation = Quaternion.Euler(0f, 0f, angle);

        Rigidbody[] slicesRig = GetComponentsInChildren<Rigidbody>(); //sliced 2 farklı parça olduğu için bu şekilde almamız gerekiyor

        foreach (Rigidbody slice in slicesRig)
        {
            //velocity : Objenin anlık hareketinin Vector3 cinsinden değeridir. Direkt atanmaması önerilir. Velocity değerini daha sağlıklı olarak değiştirmek için aşağıda bahsettiğimiz AddForce gibi fonksiyonları inceleyebilirsiniz.
            slice.velocity = _fruitRigidbody.velocity; //meyvemizin mevcut hareket halini koruyoruz
            slice.AddForceAtPosition(direction * force, position, ForceMode.Impulse);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) //other.tag'den farkı daha hızlı olması ve bellekte daha az yer kaplamasadır
        {
            Blade blade = other.GetComponent<Blade>();
            Slice(blade.direction, other.transform.position, blade.sliceForce);
        }
    }

}
