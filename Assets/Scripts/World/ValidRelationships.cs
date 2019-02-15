using Unity.Entities;

public static class ValidRelationships {

    private static ValidEntitiesGroup[] validEntityGoups = {
        new ValidEntitiesGroup(new int[] { }),                     // 0 = Error
        new ValidEntitiesGroup(new int[] { }),                     // 1 = Default
        new ValidEntitiesGroup(new int[] { 3 }),                   // 2 = Drill_Machine
        new ValidEntitiesGroup(new int[] { 2, 3 }),                // 3 = Inserter_Short
        new ValidEntitiesGroup(new int[] { 3 }),                   // 4 = Transport_Belt_Slow
    };

    class ValidEntitiesGroup {
        public int[] validEntities;

        public ValidEntitiesGroup(int[]validEntities) {
            this.validEntities = validEntities;
        }
    }

}
