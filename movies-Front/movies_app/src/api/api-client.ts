import axios from "axios";

const BASEURLFTX = "https://ftx.com/api";
const FTXURLPROXY = `https://thingproxy.freeboard.io/fetch/${BASEURLFTX}`;

export const getHttpRequest = async (uri: string):Promise<any> => {
    return await axios.get(`${FTXURLPROXY}${uri}`).then((response) => {
        return {
            data: response.data,
            error: undefined
        }
    }).catch((error) => {
        return {
            data: undefined,
            error: error?.message || "ERROR fetching data"
        }
    })
}