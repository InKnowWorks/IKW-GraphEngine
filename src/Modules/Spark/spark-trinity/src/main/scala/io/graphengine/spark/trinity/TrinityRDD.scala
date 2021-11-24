// Graph Engine
// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
//
package io.graphengine.spark.trinity

import org.apache.spark.annotation.DeveloperApi
import org.apache.spark.rdd.RDD
import org.apache.spark.sql.types._
import org.apache.spark.{Partition, SparkContext, TaskContext}

import scala.reflect.ClassTag

private[spark] class TrinityRDD[T: ClassTag](sparkContext: SparkContext,
                                schema: StructType,
                                partitions: Array[Partition],
                                retrieveCells: (Partition, StructType) => Array[Any])
  extends RDD[T](sparkContext, Nil) {

  override protected def getPartitions: Array[Partition] = partitions

  @DeveloperApi
  override def compute(split: Partition, context: TaskContext): Iterator[T] = {
    retrieveCells(split, schema).asInstanceOf[Array[T]].iterator
  }
}
