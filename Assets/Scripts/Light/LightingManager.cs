/*
Code from https://github.com/Glynn-Taylor
*/

using UnityEngine;

[ExecuteAlways]
public class LightingManager : MonoBehaviour {

    //Scene References
    [SerializeField] private Light _DirectionalLight;

    [SerializeField] private LightingPreset _Preset;

    //Variables
    [SerializeField, Range(0, 96)] private float _TimeOfDay;


    private void Update () {

        if (_Preset == null)
            return;

        if (Application.isPlaying) {
            _TimeOfDay += Time.deltaTime;
            _TimeOfDay %= 96; // day has 96 hours
            UpdateLighting(_TimeOfDay / 96f);
        } else {
            UpdateLighting(_TimeOfDay / 96f);
        }
    }


    private void UpdateLighting (float timePercent) {

        //Set ambient and fog
        RenderSettings.ambientLight = _Preset.AmbientColor.Evaluate(timePercent);
        RenderSettings.fogColor = _Preset.FogColor.Evaluate(timePercent);

        //If the directional light is set then rotate and set it's color, I actually rarely use the rotation because it casts tall shadows unless you clamp the value
        if (_DirectionalLight != null) {

            _DirectionalLight.color = _Preset.DirectionalColor.Evaluate(timePercent);
            _DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 170f, 0));
        }

    }


    //Try to find a directional light to use if we haven't set one lol
    private void OnValidate () {

        if (_DirectionalLight != null)
            return;

        //Search for lighting tab sun
        if (RenderSettings.sun != null) {
            _DirectionalLight = RenderSettings.sun;
        } else { //Search scene for light that fits criteria (directional)
            Light[] lights = GameObject.FindObjectsOfType<Light>();
            
            foreach (Light light in lights) {
                if (light.type == LightType.Directional) {
                    _DirectionalLight = light;
                    return;
                }
            }
        }
    }
}
