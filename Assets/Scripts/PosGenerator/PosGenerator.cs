using System.Collections.Generic;
using UnityEngine;

public class PosGenerator {

    private class AppearPos {
        public Vector3 Pos { get; set; }
        public float Probability { get; set; }

        public AppearPos(Vector3 pos, float probability) {
            Pos = pos;
            Probability = probability;
        }
    }

    private const float defaultProbability = 0.3f;

    private readonly List<AppearPos> appearPos;

    private List<int> appearPosTranslator;

    private float totalProbability;

    public PosGenerator() {
        appearPosTranslator = new List<int>(GameManager.posCount);
        appearPos = new List<AppearPos>(GameManager.posCount);

        var nowPos = new Vector3(-GameManager.distance * (GameManager.posCount / 2), 0f);

        for (int i = 0; i < GameManager.posCount; i++) {
            appearPos.Add(new AppearPos(nowPos, defaultProbability));
            nowPos.x += GameManager.distance;
        }
    }

    public void Init() {
        totalProbability = defaultProbability * GameManager.posCount;
        appearPosTranslator.Clear();

        for (int i = 0; i < GameManager.posCount; i++)
            appearPosTranslator.Add(i);
    }

    public Vector3 GetRandomPos() {
        float randomPoint = Random.value * totalProbability;

        for (int i = 0; i < appearPosTranslator.Count; i++) {
            if (randomPoint < appearPos[appearPosTranslator[i]].Probability)
                return GetPosByIndex(i);

            randomPoint -= appearPos[appearPosTranslator[i]].Probability;
        }

        return GetPosByIndex(appearPosTranslator.Count - 1);
    }

    private Vector3 GetPosByIndex(int index) {
        Vector3 returnPos = appearPos[appearPosTranslator[index]].Pos;
        totalProbability -= appearPos[appearPosTranslator[index]].Probability;

        for (int i = index; i < appearPosTranslator.Count - 1; i++)
            appearPosTranslator[i] = appearPosTranslator[i + 1];

        appearPosTranslator.RemoveAt(appearPosTranslator.Count - 1);
        return returnPos;
    }
}
