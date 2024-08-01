using Assets.Lawis.Factory;
using Assets.Lawis.Utils;
using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float spawnRate;
    [SerializeField] private float spawnRadio;
    [SerializeField] private GenericFactoryConfiguration<AEnemy> factoryConfig;
    private GenericFactory<AEnemy> factory;

    private GameObject playerGameObject;

    private void Awake()
    {
        factoryConfig.Init();
        factory = new EnemyFactory(factoryConfig);

        playerGameObject = GameObject.FindGameObjectWithTag("Player");
    }

    private void Start()
    {
        StartCoroutine(nameof(Spawn));
    }

    IEnumerator Spawn()
    {
        while (GameManager.Instance.IsGameActive)
        {
            Vector3 centerPosition = GeometryUtils.GetRandomPositionCircle(playerGameObject.transform.position, spawnRadio, Vector3.up);
            factory.CreateRandom(centerPosition, transform.rotation);
            yield return new WaitForSeconds(spawnRate);
        }
    }
}
