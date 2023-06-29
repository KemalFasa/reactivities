import { Container } from "semantic-ui-react";
import NavBar from "./NavBar";
import { observer } from "mobx-react-lite";
import { Route, Switch, useLocation } from "react-router-dom";
import HomePage from "../../features/home/HomePage";
import ActivityDashboard from "../../features/activities/dashboard/ActivityDashboard";
import ActivityForm from "../../features/activities/form/ActivityForm";
import ActivityDetails from "../../features/activities/details/ActivityDetails";
import TestErrors from "../../features/errors/TestErrors";
import { ToastContainer } from "react-toastify";
import NotFound from "../../features/errors/NotFound";

function App() {
  const location = useLocation();

  return (
    <>
      <ToastContainer position="bottom-right" hideProgressBar theme="colored" />
      <Route exact path="/" component={HomePage} /> {/* memisahkan homepage */}
      <Route
        path={"/(.+)"} //jika match dengan "/"+{something else}
        render={() => (
          <>
            <NavBar />
            <Container style={{ marginTop: "7em" }}>
              <Switch>
                {/* dengan 'switch' hanya akan aktif satu route saja dalam satu waktu. Shg component NotFound tidak akan selalu muncul */}
                <Route exact path="/activities" component={ActivityDashboard} />
                <Route path="/activities/:id" component={ActivityDetails} />
                <Route
                  key={location.key}
                  path={["/createActivity", "/manage/:id"]}
                  component={ActivityForm}
                />
                <Route path={"/errors"} component={TestErrors} />
                <Route component={NotFound} />{" "}
                {/* jika route tidak ditemukan, akan selalu redirect ke component NotFound */}
              </Switch>
            </Container>
          </>
        )}
      />
    </>
  );
}

export default observer(App);
