import React from "react";
import { Dimmer, Loader } from "semantic-ui-react";

interface Props {
  inverted?: boolean; //kondisi untuk dark background ketika load component
  content?: string; //untuk loading text
}

export default function LoadingComponent({
  inverted = true,
  content = "Loading...",
}: Props) {
  return (
    <Dimmer active={true} inverted={true}>
      <Loader content={content} />
    </Dimmer>
  );
}
