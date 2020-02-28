import Vue from 'vue'
import VueRouter from 'vue-router'
import about from '../views/About.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/about',
    name: 'about',
    component: about,
    meta: {
      requiresAuth: true
    },
  }
]

let router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})


router.beforeEach(async (to, from, next) => {
  let app = router.app.$data || {isAuthenticated: false};
  let authenticate = router.app.$options.methods.authenticate
  // console.log(authenticate)
  // // console.log(router)
  // // console.log(router.app)
  // // console.log(router.app.authenticate)
  if (app.isAuthenticated) {
    //already signed in, we can navigate anywhere
    next()
  } else if (to.matched.some(record => record.meta.requiresAuth)) {
    //authentication is required. Trigger the sign in process, including the return URI
    authenticate(to.path).then(() => {
      console.log('authenticating a protected url:' + to.path);
      next();
    });
  } else {
    //No auth required. We can navigate
    next()
  }
});

export default router
