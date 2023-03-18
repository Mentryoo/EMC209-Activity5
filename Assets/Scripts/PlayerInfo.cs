using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInfo : MonoBehaviourPun, IPunObservable
{
    [SerializeField] private float _currentHealth;
    [SerializeField] private string _equipment;
    [SerializeField] private ParticleSystem _colliderParticles;
    [SerializeField] private HealthBar _healthBar;
    private Collider2D _collider;
    private bool colliderIsOn = true;
    

    void Awake()
    {
        _collider = GetComponent<Collider2D>();
        if (photonView.IsMine)
        {
            _colliderParticles.Stop();
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(_currentHealth);
            stream.SendNext(_equipment);
        } 
        else
        {
            _currentHealth = (float)stream.ReceiveNext();
            _equipment = (string)stream.ReceiveNext();
        }
    }

    private void Update()
    {
        if (photonView.IsMine)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (colliderIsOn)
                {
                    SetCollider(false);
                }
                else
                {
                    SetCollider(true);
                }
            }
        }
    }

    private void SetCollider(bool isEnabled)
    {
        colliderIsOn = isEnabled;
        _collider.enabled = isEnabled;
        if(isEnabled)
        {
            _colliderParticles.Play();
        } 
        else
        {
            _colliderParticles.Stop();
        }
    }

    public void DamagePlayer(float damage)
    {
        _currentHealth -= damage;
        _healthBar.SetHealth(_currentHealth);
        if (_currentHealth <= -100)
        {
            Respawn();
        }
    }

    private void Respawn()
    {
        _currentHealth = 0;
        _healthBar.SetHealth(0);
        gameObject.transform.position = new Vector3(-6.55f, -1.25f, 0);
    }
}
