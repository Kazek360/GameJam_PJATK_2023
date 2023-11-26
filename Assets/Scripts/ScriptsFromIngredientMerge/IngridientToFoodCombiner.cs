using System.Collections.Generic;
using UnityEngine;

namespace ScriptsFromIngredientMerge
{
    public class IngridientToFoodCombiner : MonoBehaviour
    {
        public List<string> recipeTags;

        private List<string> ingredientsInside = new List<string>();
        [SerializeField] private Transform _ovenIngredientGrabberZone;
        [SerializeField] private float _ovenIngredientGrabberZoneRange;
        [SerializeField] private LayerMask _ingredientLayerMask;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private GameObject _dish;
        private Color _gizmosColor;

        private void Update()
        {
            TakeIngredients();
        }

        private void TakeIngredients()
        {
            Collider2D[] ingredientsInRange = Physics2D.OverlapCircleAll(
                _ovenIngredientGrabberZone.position,
                _ovenIngredientGrabberZoneRange,
                _ingredientLayerMask
            );
        
            if (ingredientsInRange.Length > 0)
            {
                foreach (Collider2D ingredientCollider in ingredientsInRange)
                {
                    string ingredientTag = ingredientCollider.tag;

                    ingredientsInside.Add(ingredientTag);

                    Destroy(ingredientCollider.gameObject);
                }
                CheckRecipe();
            }
        }

        private void CheckRecipe()
        {
            if (IngredientsMatchRecipe())
            {
                CreateDish();
            }
        }

        private bool IngredientsMatchRecipe()
        {
            if (ingredientsInside.Count == recipeTags.Count)
            {
                for (int i = 0; i < ingredientsInside.Count; i++)
                {
                    if (!ingredientsInside.Contains(recipeTags[i]))
                    {
                        return false;
                    }
                }
                return true;
            }

            return false;
        }

        private void CreateDish()
        {
            AudioManager.instance.Play("Combine");
            GameObject dishPrefab = Instantiate(_dish, _spawnPoint.position, Quaternion.identity);
        
            ingredientsInside.Clear();
        }
    
        private void OnDrawGizmos()
        {
            _gizmosColor = Color.yellow;
            Gizmos.color = _gizmosColor;
            Gizmos.DrawWireSphere(_ovenIngredientGrabberZone.position, _ovenIngredientGrabberZoneRange);
        }
    
    }
}
