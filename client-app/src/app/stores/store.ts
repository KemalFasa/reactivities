import { createContext, useContext } from "react";
import ActivityStore from "./activityStore";

interface Store {
  activityStore: ActivityStore; //class bisa digunakan sebagai types
}

export const store: Store = {
  activityStore: new ActivityStore(),
};

export const StoreContext = createContext(store); //menambahkan pada react context

//create simple hook
export function useStore() {
  return useContext(StoreContext);
}
