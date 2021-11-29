const get = (key) => {
    return JSON.parse(localStorage.getItem(key));
}
const set = (key, data) => {
   localStorage.setItem(key,JSON.stringify(data));
}
const remove= (key)=>{
    localStorage.removeItem(key);
}
export default {
    get,
    set,
    remove
}