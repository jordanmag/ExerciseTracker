import { extendObservable } from 'mobx'

class UserStore {
    constructor() {
        extendObservable(this, {
            loading: true,
            isLoggedIn: false, // TODO: Take this out and get this via API
            username: ''
        })
    }
}

export default new UserStore();